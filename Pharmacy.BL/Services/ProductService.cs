using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
        {
            var productsModel = await db.Products.Select(_=> new ProductModel { 
                Id = _.Id,
                Name = _.Name,
                Article = _.Article,
                Description = _.Description
            }).AsNoTracking().ToListAsync();

            return productsModel;
        }

        public async Task<ProductModel> GetProductByIdAsync(int id)
        {
            var product = await db.Products.FirstOrDefaultAsync(_ => _.Id == id);

            if (product == null)
            {
                return null;
            }

            return new ProductModel()
            {
                Id = product.Id,
                Name = product.Name,
                Article = product.Article,
                Description = product.Description
            };
        }

        public async Task<ProductModel> SaveProductAsync(ProductModel productModel)
        {
            var product = await db.Products.FirstOrDefaultAsync(_ => _.Id == productModel.Id);

            if (product != null)
            {
                product.Name = productModel.Name;
                product.Article = productModel.Article;
                product.Description = product.Description;
            }
            else
            {
                product = new Product()
                {
                    Id = productModel.Id,
                    Name = productModel.Name,
                    Article = productModel.Article,
                    Description = productModel.Description
                };
                db.Add(product);
            }

            await db.SaveChangesAsync();

            return new ProductModel(product);
        }

        public async Task<IEnumerable<ProductModel>> SaveProductsAsync(IEnumerable<ProductModel> productsModel)
        {
            var result = new List<ProductModel>();
            foreach (var productModel in productsModel)
            {
                var product = await db.Products.FirstOrDefaultAsync(_ => _.Id == productModel.Id);

                if (product != null)
                {
                    product.Name = productModel.Name;
                    product.Article = productModel.Article;
                    product.Description = productModel.Description;
                    //db.Entry(product).State = EntityState.Modified; //?
                }
                else
                {
                    product = new Product()
                    {
                        Id = productModel.Id,
                        Name = productModel.Name,
                        Article = productModel.Article,
                        Description = productModel.Description
                    };
                    db.Add(product);
                    result.Add(new ProductModel(product));
                }
            }

            await db.SaveChangesAsync();

            return result;
        }
    }
}
