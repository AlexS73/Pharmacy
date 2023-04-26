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
    public class PriceService : IPriceService
    {
        private readonly PharmacyContext db;

        public PriceService(PharmacyContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<ProductPriceModel>> GetPrices()
        {
            return await db.ProductPrices.AsNoTracking().Select(_=> new ProductPriceModel(_)).ToListAsync();
        }

        public async Task<IEnumerable<ProductPriceModel>> GetPricesByDepartment(int departmentId)
        {
            return await db.ProductPrices
                .Include(_=> _.Warehouse)
                .Where(_=> _.Warehouse.DepartmentId == departmentId)
                .AsNoTracking()
                .Select(_ => new ProductPriceModel(_))
                .ToListAsync();
        }

        public async Task<ProductPriceModel> Save(ProductPriceModel productPrice)
        {
            if (productPrice.Id != 0)
            {
               var priceInDb = await db.ProductPrices.FindAsync(productPrice.Id);
               priceInDb.Price = productPrice.Price;
               await db.SaveChangesAsync();
               return new ProductPriceModel(priceInDb);
            }
            else
            {
                var newProductPrice = new ProductPrice()
                {
                    Price = productPrice.Price,
                    ProductId = productPrice.ProductId,
                    WarehouseId = productPrice.WarehouseId
                };
                await db.ProductPrices.AddAsync(newProductPrice);
                await db.SaveChangesAsync();
                return new ProductPriceModel(newProductPrice);

            }
        }

        public Task<IEnumerable<ProductPriceModel>> SavePrices(ProductPriceModel price)
        {
            throw new NotImplementedException();
        }
    }
}
