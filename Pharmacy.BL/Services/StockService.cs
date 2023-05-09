using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pharmacy.BL.Interfaces;
using Pharmacy.Core.Models;
using Pharmacy.Entity;

namespace Pharmacy.BL.Services
{
    public class StockService : IStockService
    {
        private readonly PharmacyContext db;

        public StockService(PharmacyContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<ProductStockModel>> Get()
        {
            return await this.db.ProductStocks
                .Include(_ => _.Product)
                .Include(_ => _.Warehouse)
                .AsNoTracking()
                .Select(_ => new ProductStockModel(_))
                .ToListAsync();
        }
    }
}
