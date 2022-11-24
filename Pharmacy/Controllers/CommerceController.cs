using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommerceController : ControllerBase
    {
        private readonly ICommerceService commerceService;
        private readonly UserManager<User> userManager;


        public CommerceController(ICommerceService commerceService, UserManager<User> userManager)
        {
            this.commerceService = commerceService;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("sale")]
        public async Task<SaleModel> CreateSale(SaleModel saleModel)
        {
            var user = await userManager.GetUserAsync(this.User);

            var newSale = await commerceService.CreateSaleAsync(saleModel, user);
            return newSale;
        }

        [HttpPost]
        [Route("entrance")]
        public async Task<EntranceModel> CreateEntrance(EntranceModel entranceModel)
        {
            var user = await userManager.GetUserAsync(this.User);

            var newEntrance = await commerceService.CreateEntranceAsync(entranceModel, user);
            return newEntrance;
        }

    }
}
