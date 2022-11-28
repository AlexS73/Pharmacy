using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pharmacy.BL.Interfaces;
using Pharmacy.Core.Models;
using Pharmacy.Entity;

namespace Pharmacy.BL.Services
{
    public class WarehouseService: IWarehouseService
    {
        private readonly PharmacyContext db;
        
        public async Task<IEnumerable<WarehouseModel>> GetLeftoversAsync()
        {
            return await db.Warehouse.Select(_=> new WarehouseModel(_)).ToListAsync();
        }
    }
}