using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.BL.Services;
using Pharmacy.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Pharmacy.BL.Interfaces;
using Pharmacy.Entity;

namespace Pharmacy.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService stockService;
        private readonly UserManager<User> userManager;

        public StockController(IStockService stockService, UserManager<User> userManager)
        {
            this.stockService = stockService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductStockModel>>> Get()
        {
            var currentUser = await userManager.GetUserAsync(User);
            if (await userManager.IsInRoleAsync(currentUser, "administrator"))
            {
                var result = await stockService.Get();
                return Ok(result);
            }
            else
            {
                var result = await stockService.GetByDepartment(currentUser.DepartmentId);
                return Ok(result);
            }

        }
    }
}
