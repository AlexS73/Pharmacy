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
            return await db.ProductPrices
                .Include(_ => _.Warehouse)
                .Include(_ => _.Product)
                .AsNoTracking()
                .Select(_ => new ProductPriceModel(_))
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductPriceModel>> GetPricesByDepartment(int departmentId)
        {
            return await db.ProductPrices
                .Include(_=> _.Warehouse)
                .Include(_=> _.Product)
                .Where(_=> _.Warehouse.DepartmentId == departmentId)
                .AsNoTracking()
                .Select(_ => new ProductPriceModel(_))
                .ToListAsync();
        }

        public async Task<ProductPriceModel> Create(ProductPriceModel productPrice)
        {
            var newProductPrice = new ProductPrice()
            {
                Price = productPrice.Price,
                ProductId = productPrice.Product.Id,
                WarehouseId = productPrice.WarehouseId
            };
            await db.ProductPrices.AddAsync(newProductPrice);
            await db.SaveChangesAsync();
            var res = await db.ProductPrices
                .Include(_ => _.Warehouse)
                .Include(_ => _.Product)
                .Where(_ => _.Id == newProductPrice.Id).FirstOrDefaultAsync();
                
            return new ProductPriceModel(res);
        }
        public async Task<ProductPriceModel> Edit(ProductPriceModel productPrice)
        {
            var priceInDb = await db.ProductPrices
                .Include(_=>_.Product)
                .Include(_=>_.Warehouse)
                .Where(_=>_.Id == productPrice.Id).FirstOrDefaultAsync();
            priceInDb.Price = productPrice.Price;
            await db.SaveChangesAsync();
            return new ProductPriceModel(priceInDb);
        }

        public Task<IEnumerable<ProductPriceModel>> SavePrices(ProductPriceModel price)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(int priceId)
        {
            var dbPrice = await db.ProductPrices.FindAsync(priceId);
            db.ProductPrices.Remove(dbPrice);
            await db.SaveChangesAsync();
        }
    }
}
