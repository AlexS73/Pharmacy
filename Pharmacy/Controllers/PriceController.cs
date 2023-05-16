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
using Microsoft.AspNetCore.Authorization;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IPriceService priceService;
        private readonly UserManager<User> userManager;

        public PriceController(IPriceService priceService, UserManager<User> userManager)
        {
            this.priceService = priceService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductPriceModel>> GetPrices()
        {
            var currentUser = await userManager.GetUserAsync(this.User);
            if (await userManager.IsInRoleAsync(currentUser,"administrator"))
            {
                return await priceService.GetPrices();
            }
            
            return await priceService.GetPricesByDepartment(currentUser.DepartmentId);
        }

        [Authorize(Roles = "administrator")]
        [HttpPost]
        public async Task<ActionResult<ProductPriceModel>> SavePrice(ProductPriceModel productPrice)
        {
            try
            {

                if (productPrice.Id != 0)
                {
                    return await priceService.Edit(productPrice);
                }
                else
                {
                    return await priceService.Create(productPrice);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ;
            }
        }

        [Route("remove")]
        [Authorize(Roles = "administrator")]
        [HttpPost]
        public async Task<ActionResult> RemovePrice(int priceId)
        { 
            await priceService.Remove(priceId);
            return Ok();
        }

    }
}
