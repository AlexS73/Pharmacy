using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pharmacy.BL.Interfaces;
using Pharmacy.Core.Models;
using Pharmacy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BL.Services
{
    public class AccountService : IAccountService
    {
        private readonly PharmacyContext db;
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;

        public AccountService(PharmacyContext db, UserManager<User> userManager, ITokenService tokenService)
        {
            this.db = db;
            this.userManager = userManager;
            this.tokenService = tokenService;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            User user = db.User.Include(_=>_.Department).FirstOrDefault(_ => _.UserName == model.Username);

            if (user == null) return null;

            var passCorrect = await userManager.CheckPasswordAsync(user, model.Password);

            if (!passCorrect) return null;

            string jwtToken = await tokenService.GenerateJwtToken(user);
            RefreshToken refreshToken = tokenService.GenerateRefreshToken();

            user.RefreshTokens.Add(refreshToken);
            db.Update(user);
            await db.SaveChangesAsync();

            var roles = await userManager.GetRolesAsync(user);

            var currentUserModel = new UserModel(user)
            {
                Roles = roles
            };

            return new AuthenticateResponse(currentUserModel, jwtToken, refreshToken.Token);
        }

        public async Task<UserModel> GetCurrentUserAsync(ClaimsPrincipal user)
        {
            var currentUserId = userManager.GetUserId(user);
            var currentUser = await db.User
                .Include(_=>_.Department)
                .FirstAsync(_=>_.Id == int.Parse(currentUserId));

            var roles = await userManager.GetRolesAsync(currentUser);

            var currentUserModel = new UserModel(currentUser)
            {
                Roles = roles
            };

            return currentUserModel;
        }

        public async Task<AuthenticateResponse> RefreshToken(string refreshToken)
        {
            var user = db.User.Include(_ => _.Department).SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == refreshToken));

            // return null if no user found with token
            if (user == null) return null;

            var userRefreshToken = user.RefreshTokens.Single(x => x.Token == refreshToken);

            // return null if token is no longer active
            if (!userRefreshToken.IsActive) return null;

            // replace old refresh token with a new one and save
            var newRefreshToken = tokenService.GenerateRefreshToken();
            userRefreshToken.Revoked = DateTime.UtcNow;
            userRefreshToken.ReplacedByToken = newRefreshToken.Token;
            user.RefreshTokens.Add(newRefreshToken);
            db.Update(user);
            db.SaveChanges();

            // generate new jwt
            var jwtToken = await tokenService.GenerateJwtToken(user);

            var roles = await userManager.GetRolesAsync(user);

            var currentUserModel = new UserModel(user)
            {
                Roles = roles
            };

            return new AuthenticateResponse(currentUserModel, jwtToken, newRefreshToken.Token);
        }

        public async Task<AuthenticateResponse> Registration(RegistrationRequest model)
        {
            User newUser = new User() { UserName = model.Email, DepartmentId = model.DepartmentId, Email = model.Email };

            var res = await userManager.CreateAsync(newUser, model.Password);

            if (!res.Succeeded)
            {
                return null;
            }

            User createdUser = db.User
                .Include(_ => _.RefreshTokens)
                .Include(_ => _.Department)
                .FirstOrDefault(_ => _.UserName == newUser.UserName);

            // генерация refresh при успешной регистрации
            string jwtToken = await tokenService.GenerateJwtToken(createdUser);
            RefreshToken refreshToken = tokenService.GenerateRefreshToken();

            createdUser.RefreshTokens.Add(refreshToken);
            db.Update(createdUser);
            await db.SaveChangesAsync();

            var roles = await userManager.GetRolesAsync(createdUser);

            var currentUserModel = new UserModel(createdUser)
            {
                Roles = roles
            };

            return new AuthenticateResponse(currentUserModel, jwtToken, refreshToken.Token);
        }

        public bool RevokeToken(string token)
        {
            var user = db.User.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));

            // return false if no user found with token
            if (user == null) return false;

            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            // return false if token is not active
            if (!refreshToken.IsActive) return false;

            // revoke token and save
            refreshToken.Revoked = DateTime.UtcNow;
            db.Update(user);
            db.SaveChanges();

            return true;
        }
    }
}
