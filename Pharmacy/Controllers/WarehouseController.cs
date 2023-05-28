using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.BL.Interfaces;
using Pharmacy.Core.Models;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService warehouseService;
        public WarehouseController(IWarehouseService warehouseService)
        {
            this.warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarehouseModel>>> Get()
        {
            try
            {
                var result = await warehouseService.GetAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<WarehouseModel>>> Save(WarehouseModel warehouseModel)
        {
            try
            {
                var result = await warehouseService.SaveAsync(warehouseModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }


    }
}