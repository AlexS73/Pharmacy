using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.BL.Interfaces;
using Pharmacy.Core.Models;
using Pharmacy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly IPriceService priceService;
        private readonly UserManager<User> userManager;

        public PricesController(IPriceService priceService, UserManager<User> userManager)
        {
            this.priceService = priceService;
            this.userManager = userManager;
        }

        [Route("/all")]
        public async Task<IEnumerable<PriceModel>> GetPrices()
        {
            return await priceService.GetPrices();
        }

        
        public async Task<IEnumerable<PriceModel>> GetPricesByUserDepartment()
        {
            var user = await userManager.GetUserAsync(this.User);
            return await priceService.GetPricesByDepartment(user.DepartmentId);
        }

    }
}
