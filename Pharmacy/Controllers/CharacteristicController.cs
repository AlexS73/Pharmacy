using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.BL.Interfaces;
using Pharmacy.BL.Services;
using Pharmacy.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacteristicController : ControllerBase
    {
        private readonly ICharacteristicService characteristicService;

        public CharacteristicController(ICharacteristicService characteristicService)
        {
            this.characteristicService = characteristicService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProducts()
        {
            try
            {
                var result = await characteristicService.GetTypes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CharacteristicTypeModel>> SaveProduct(CharacteristicTypeModel charType)
        {
            var updatedCharType = await characteristicService.SaveType(charType);
            return updatedCharType;
        }
    }
}
