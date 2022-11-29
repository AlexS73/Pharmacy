using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementController : ControllerBase
    {
        private readonly IAdministrationService managementService;

        public ManagementController(IAdministrationService managementService)
        {
            this.managementService = managementService;
        }

        [HttpGet]
        public async Task<ActionResult> SyncProducts()
        {
            await managementService.LoadProductsAsync();
            return Ok();
        }
    }
}
