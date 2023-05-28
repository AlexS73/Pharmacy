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

        public async Task<DepartmentModel> SaveDepartmentAsync(DepartmentModel departmentModel)
        {
            var department = await db.Departments.FirstOrDefaultAsync(_=>_.Id == departmentModel.Id);

            if(department != null)
            {
                department.Name = departmentModel.Name;
                department.Address = departmentModel.Address;
            }
            else
            {
                department = new Department()
                {
                    Name = departmentModel.Name,
                    Address = departmentModel.Address
                };
                db.Add(department);
            }

            await db.SaveChangesAsync();

            return new DepartmentModel(department);
        }

        public async Task<DepartmentModel> GetDepartmentByIdAsync(int id)
        {
            var dbDepartment = await db.Departments.Include(_ => _.Warehouse).AsNoTracking().FirstOrDefaultAsync(_ => _.Id == id);

            if (dbDepartment == null)
            {
                return null;
            }
            return new DepartmentModel(dbDepartment);
        }

        public async Task<IEnumerable<DepartmentModel>> GetDepartmentsAsync()
        {
            return await db.Departments.Include(_=>_.Warehouse).AsNoTracking().Select(_=> new DepartmentModel(_)).ToListAsync();
        }
    }
}
