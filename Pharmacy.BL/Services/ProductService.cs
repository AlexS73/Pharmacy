﻿using Microsoft.EntityFrameworkCore;
using Pharmacy.BL.Interfaces;
using Pharmacy.Core.Models;
using Pharmacy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
            var productsModel = await db.Products
                .Include(_=> _.Characteristics)
                //.ThenInclude(_=>_.Type)
                .AsNoTracking()
                .Select(_ => new ProductModel(_))
                .ToListAsync();

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
            var product = await db.Products.Include(_=>_.Characteristics).FirstOrDefaultAsync(_ => _.Id == productModel.Id);
            var charTypes = await db.CharacteristicTypes.ToListAsync();

            if (product != null)
            {
                product.Name = productModel.Name;
                product.Article = productModel.Article;
                product.Description = productModel.Description;
            }
            else
            {

                product = new Product()
                {
                    //Id = productModel.Id,
                    Name = productModel.Name,
                    Article = productModel.Article,
                    Description = productModel.Description,
                };

                db.Add(product);
            }

            product.Characteristics = new List<Characteristic>();

            foreach (var characteristic in productModel.Characteristics)
            {
                var charType = charTypes.Find(_ => _.Id == characteristic.TypeId);
                var dbChar = db.Characteristics.FirstOrDefault(_ => _.Type == charType && _.Value == characteristic.Value);

                
                if (dbChar != null)
                {
                    if(!product.Characteristics.Contains(dbChar))
                        product.Characteristics.Add(dbChar);
                }
                else
                {
                    var newCharacteristic = new Characteristic()
                    {
                        Type = charType,
                        Value = characteristic.Value,
                        Products = new List<Product>()
                    };

                    product.Characteristics.Add(newCharacteristic);
                }
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

        public async Task<IEnumerable<ProductViewModel>> GetViewProducts(int departmentId)
        {
            var typeCategory = await db.CharacteristicTypes.FirstOrDefaultAsync(_ => _.Name == "Категория");
            var warehouse = await db.Warehouse.FirstOrDefaultAsync(_ => _.DepartmentId == departmentId);

            if (warehouse == null || typeCategory == null)
            {
                return new List<ProductViewModel>();
            }

            var prices = await db.ProductPrices
                .Where(p=> p.WarehouseId == warehouse.Id)
                .AsNoTracking()
                .ToListAsync();

            try
            {
                var products = await db.ProductStocks
                    .Include(ps => ps.Warehouse)
                    .Include(ps => ps.Product)
                    .ThenInclude(p => p.Characteristics)
                    .AsNoTracking()
                    .Where(ps => ps.WarehouseId == warehouse.Id)
                    .Select(ps => new ProductViewModel()
                    {
                        Id = ps.ProductId,
                        Name = ps.Product.Name,
                        Article = ps.Product.Article,
                        Description = ps.Product.Description,
                        Warehouse = new WarehouseModel(ps.Warehouse),
                        Stock = ps.Count,
                        //Price = prices.FirstOrDefault(price => price.ProductId == ps.ProductId && price.WarehouseId == ps.WarehouseId) == null ? -1 :
                        //    prices.First(price => price.ProductId == ps.ProductId && price.WarehouseId == ps.WarehouseId).Price,
                        Category = ps.Product.Characteristics.FirstOrDefault(c => c.Type == typeCategory) == null ? "" :
                            ps.Product.Characteristics.First(c => c.Type == typeCategory).Value

                    }).ToListAsync();

                foreach (var product in products)
                {
                    product.Price =
                        prices.FirstOrDefault(price =>
                            price.ProductId == product.Id && price.WarehouseId == product.Warehouse.Id) == null
                            ? -1
                            : prices.First(price =>
                                price.ProductId == product.Id && price.WarehouseId == product.Warehouse.Id).Price;
                }

                return products;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<string>> GetCategories()
        {
            return await db.Characteristics
                .Include(_ => _.Type)
                .Where(_ => _.Type.Name == "Категория")
                .Select(_ => _.Value)
                .ToListAsync();
        }
    }
}
