﻿using Microsoft.AspNetCore.Http;
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
    public class PriceController : ControllerBase
    {
        private readonly IPriceService priceService;
        private readonly UserManager<User> userManager;

        public PriceController(IPriceService priceService, UserManager<User> userManager)
        {
            this.priceService = priceService;
            this.userManager = userManager;
        }

        [Route("/all")]
        public async Task<IEnumerable<ProductPriceModel>> GetPrices()
        {
            return await priceService.GetPrices();
        }

        
        public async Task<IEnumerable<ProductPriceModel>> GetPricesByUserDepartment()
        {
            var user = await userManager.GetUserAsync(this.User);
            return await priceService.GetPricesByDepartment(user.DepartmentId);
        }

        [HttpPost]
        public async Task<ProductPriceModel> SavePrice(ProductPriceModel productPrice)
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

    }
}
