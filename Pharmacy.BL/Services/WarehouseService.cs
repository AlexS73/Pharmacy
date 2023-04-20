using System;
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
        private readonly IAdministrationService adminService;

        public WarehouseService(PharmacyContext db, IAdministrationService adminService)
        {
            this.db = db;
            this.adminService = adminService;
        }

        public async Task<IEnumerable<WarehouseModel>> GetLeftoversAsync()
        {
            throw new NotImplementedException();
            //return await db.Warehouse
            //    .Include(_=>_.Product)
            //    .Select(_=> new WarehouseModel(_))
            //    .ToListAsync();
        }

        public async Task<IEnumerable<WarehouseModel>> GetLeftoversAsync(string department)
        {
            return await adminService.LoadLeftoversAsync(department);
        }
    }
}