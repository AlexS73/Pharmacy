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
    public class DepartmentService : IDepartmentService
    {
        private readonly PharmacyContext db;

        public DepartmentService(PharmacyContext db)
        {
            this.db = db;
        }

        public async Task CreateDepartmentAsync(DepartmentModel departmentModel)
        {
            var newDepartment = new Department()
            {
                Name = departmentModel.Name
            };
            db.Add(newDepartment);

            await db.SaveChangesAsync();
        }

        public async Task<DepartmentModel> GetDepartmentByIdAsync(int id)
        {
            var dbDepartment = await db.Departments.FirstOrDefaultAsync(_ => _.Id == id);
            return new DepartmentModel()
            {
                Id = dbDepartment.Id,
                Name = dbDepartment.Name
            };
        }

        public async Task<IEnumerable<DepartmentModel>> GetDepartmentsAsync()
        {
            return await db.Departments.Select(_=> new DepartmentModel()
            {
                Id = _.Id,
                Name = _.Name
            }).ToListAsync();
        }
    }
}
