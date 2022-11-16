using Pharmacy.BL.Interfaces;
using Pharmacy.Core.Models;
using Pharmacy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BL.Services
{
    public class ProductService : IProductService
    {
        private readonly PharmacyContext db;

        public ProductService(PharmacyContext db)
        {
            this.db = db;
        }

        public async Task CreateProducts(IEnumerable<ProductModel> productsModel)
        {
            var newProducts = productsModel.Select(_ => new Product() {
                Article = _.Article,
                Name = _.Name,
                Id = _.Id
            });

            db.Products.AddRange(newProducts);
            await db.SaveChangesAsync();
        }

        public async Task CreateProdut(ProductModel product)
        {
            var newProduct = new Product()
            {
                Article = product.Article,
                Name = product.Name,
            };

            db.Products.AddRange(newProduct);
            await db.SaveChangesAsync();
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            var productsModel =  db.Products.Select(_=> new ProductModel { 
                Id = _.Id,
                Name = _.Name,
                Article = _.Article
            }).ToList();

            return productsModel;
        }
    }
}
