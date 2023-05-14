using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.BL.Interfaces;
using Pharmacy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Pharmacy.Entity;

namespace Pharmacy.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly UserManager<User> userManager;

        public ProductController(IProductService productService, UserManager<User> userManager)
        {
            this.productService = productService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProducts()
        {
            try
            {
                var result = await productService.GetAllProductsAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProduct(int id)
        {

            var product = await productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<ProductModel>> SaveProduct(ProductModel product)
        {
            try
            {
                var updatedProduct = await productService.SaveProductAsync(product);
                return updatedProduct;
            }
            catch (Exception e)
            {

                throw;
            }

        }

        [HttpGet("view")]
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<ProductViewModel>> GetProductView()
        {
            var currentUser = await userManager.GetUserAsync(User);
            var product = await productService.GetViewProducts(currentUser.DepartmentId);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProductCategories()
        {

            var result = await productService.GetCategories();
            return Ok(result);

        }

    }
}
