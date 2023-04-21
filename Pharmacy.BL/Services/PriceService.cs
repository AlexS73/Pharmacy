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

        public async Task<IEnumerable<PriceModel>> GetPrices()
        {
            return await db.ProductPrices.AsNoTracking().Select(_=> new PriceModel(_)).ToListAsync();
        }

        public async Task<IEnumerable<PriceModel>> GetPricesByDepartment(int departmentId)
        {
            return await db.ProductPrices
                .Include(_=> _.Warehouse)
                .Where(_=> _.Warehouse.DepartmentId == departmentId)
                .AsNoTracking()
                .Select(_ => new PriceModel(_))
                .ToListAsync();
        }

        public Task<IEnumerable<PriceModel>> SavePrices(PriceModel price)
        {
            throw new NotImplementedException();
        }
    }
}
