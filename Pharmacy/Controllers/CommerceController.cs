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
    public class CommerceController : ControllerBase
    {
        private readonly ICommerceService commerceService;

        public CommerceController(ICommerceService commerceService)
        {
            this.commerceService = commerceService;
        }


    }
}
