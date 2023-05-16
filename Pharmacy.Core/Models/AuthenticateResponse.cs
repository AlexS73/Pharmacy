using Pharmacy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models
{
    public class AuthenticateResponse
    {
        public AuthenticateResponse(UserModel user, string jwtToken, string refreshToken)
        {
            //Id = user.Id;
            //UserName = user.UserName;
            //Department = user.Department.Name;
            this.User = user;
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
        }

        public UserModel User { get; set; }
        //public int Id { get; set; }
        //public string UserName { get; set; }
        //public string Department { get; set; }
        public string JwtToken { get; set; }

        [JsonIgnore] //возвращается в http only cookie
        public string RefreshToken { get; set; }
    }
}
