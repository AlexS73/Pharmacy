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
    }
}
