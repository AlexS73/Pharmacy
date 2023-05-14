using Pharmacy.Core.Models;
using Pharmacy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BL.Interfaces
{
    public interface IUserService
    {
        User GetById(int id);

        Task<ClaimsIdentity> GetIdentity(User user);
        Task<ICollection<UserModel>> GetUsersAsync();
        Task<UserModel> GetCurrentUserAsync(ClaimsPrincipal user);
        Task<ICollection<string>> GetRolesAllAsync();
        Task<UserModel> SaveAsync(UserModel user);
    }
}
