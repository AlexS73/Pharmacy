using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.BL.Services;
using Pharmacy.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Pharmacy.BL.Interfaces;

namespace Pharmacy.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService stockService;

        public StockController(IStockService stockService)
        {
            this.stockService = stockService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductStockModel>>> Get()
        {
            var result = await stockService.Get();
            return Ok(result);
        }
    }
}
