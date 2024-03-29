﻿using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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

        [HttpGet]
        [Route("sales")]
        public async Task<IEnumerable<SaleModel>> GetSales()
        {
            var currentUser = await userManager.GetUserAsync(User);
            if (await userManager.IsInRoleAsync(currentUser, "administrator"))
            {
                IEnumerable<SaleModel> sales = await commerceService.GetSales();
                return sales;
            }
            else
            {
                IEnumerable<SaleModel> sales = await commerceService.GetSalesByDepartment(currentUser.DepartmentId);
                return sales;
            }
            
        }
        
        [HttpGet]
        [Route("entrances")]
        public async Task<IEnumerable<EntranceModel>> GetEntrances()
        {
            var currentUser = await userManager.GetUserAsync(User);
            if (await userManager.IsInRoleAsync(currentUser, "administrator"))
            {
                IEnumerable<EntranceModel> entrances = await commerceService.GetEntrances();
                return entrances;
            }
            else
            {
                IEnumerable<EntranceModel> entrances = await commerceService.GetEntrancesByDepartment(currentUser.DepartmentId);
                return entrances;
            }
            
        }
        
        [HttpGet]
        [Route("sale/{id}")]
        public async Task<SaleModel> GetSaleById(int id)
        {
            SaleModel sale = await commerceService.GetSaleById(id);
            return sale;
        }
        
        [HttpGet]
        [Route("entrance/{id}")]
        public async Task<ActionResult<EntranceModel>> GetEntranceById(int id)
        {
            EntranceModel entrance = await commerceService.GetEntranceById(id);
            return entrance;
        }
        
        [HttpPost]
        [Route("sale")]
        public async Task<ActionResult<SaleModel>> CreateSale(SaleModel saleModel)
        {
            try
            {
                var user = await userManager.GetUserAsync(this.User);

                var newSale = await commerceService.CreateSaleAsync(saleModel, user);
                return newSale;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }

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
