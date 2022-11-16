using Pharmacy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BL.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateJwtToken(User user);
        RefreshToken GenerateRefreshToken();
    }
}
