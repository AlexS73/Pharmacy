using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.BL.Services;
using Pharmacy.Core.Models;
using System.Threading.Tasks;
using Pharmacy.BL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        

        public UserController(IUserService userService)
        {
            this.userService = userService;

        }


        [HttpGet("all")]
        [Authorize(Roles="administrator")]
        [ResponseCache(Duration = 60)]
        public async Task<ICollection<UserModel>> GetUsers()
        {
            return await userService.GetUsersAsync();
        }

        [HttpGet("currentUser")]
        [Authorize]
        [ResponseCache(Duration = 60)]
        public async Task<UserModel> GetCurrentUser()
        {
            return await userService.GetCurrentUserAsync(User);
        }

        [HttpGet("roles-all")]
        [Authorize]
        [ResponseCache(Duration = 60)]
        public async Task<ICollection<string>> GetRoles()
        {
            return await userService.GetRolesAllAsync();
        }

        [HttpPost("save")]
        [Authorize(Roles = "administrator")]
        public async Task<UserModel> Save(UserModel user)
        {
            return await userService.SaveAsync(user);
        }
    }
}
