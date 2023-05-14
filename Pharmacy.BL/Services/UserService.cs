using Microsoft.AspNetCore.Identity;
using Pharmacy.BL.Interfaces;
using Pharmacy.Core.Models;
using Pharmacy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Pharmacy.BL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;
        private readonly PharmacyContext db;

        public UserService(UserManager<User> userManager, PharmacyContext db, RoleManager<IdentityRole<int>> roleManager)
        {
            this.userManager = userManager;
            this.db = db;
            this.roleManager = roleManager; 
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ClaimsIdentity> GetIdentity(User user)
        {
            var roles = await userManager.GetRolesAsync(user);
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    //new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", user.Id.ToString()),
                };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role));
            }
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            
            /*ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                ClaimsIdentity.DefaultRoleClaimType);*/

            return claimsIdentity;
        }

        public async Task<ICollection<UserModel>> GetUsersAsync()
        {
            var users = await this.db.User.Include(_ => _.Department).AsNoTracking().ToListAsync();

            var usersModel = users.Select(_ => new UserModel(_)
            {
                Roles = userManager.GetRolesAsync(_).GetAwaiter().GetResult()
            }).ToList();

            return usersModel;

        }

        public async Task<UserModel> GetCurrentUserAsync(ClaimsPrincipal user)
        {
            var currentUserId = userManager.GetUserId(user);
            var currentUser = await db.User
                .Include(_ => _.Department)
                .FirstAsync(_ => _.Id == int.Parse(currentUserId));

            var roles = await userManager.GetRolesAsync(currentUser);

            var currentUserModel = new UserModel(currentUser)
            {
                Roles = roles
            };

            return currentUserModel;
        }


        public async Task<ICollection<string>> GetRolesAllAsync()
        {
            var roles = await roleManager.Roles.Select(_ => _.Name).ToListAsync();
            return roles;
        }

        public async Task<UserModel> SaveAsync(UserModel user)
        {
            var dbUser = await db.User.Include(_=>_.Department)
                .FirstAsync(_=> _.Id == user.Id && _.UserName == user.UserName);

            
            var existingRoles = await userManager.GetRolesAsync(dbUser);
            var newRoles = user.Roles.ToList();

            var rolesForAdd = newRoles.Except(existingRoles).ToList();
            var rolesForRemove = existingRoles.Except(newRoles).ToList();

            await userManager.RemoveFromRolesAsync(dbUser, rolesForRemove);
            await userManager.AddToRolesAsync(dbUser, rolesForAdd);

            var roles = await userManager.GetRolesAsync(dbUser);

            var updatedUserModel = new UserModel(dbUser)
            {
                Roles = roles
            };

            return updatedUserModel;

        }
    }
}
