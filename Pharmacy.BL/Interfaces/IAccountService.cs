using Pharmacy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BL.Interfaces
{
    public interface IAccountService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task<AuthenticateResponse> Registration(RegistrationRequest model);
        Task<AuthenticateResponse> RefreshToken(string refreshToken);
        bool RevokeToken(string token);
    }
}
