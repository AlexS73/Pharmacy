using Pharmacy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BL.Interfaces
{
    public interface IDepartmentService
    {
        Task<DepartmentModel> SaveDepartmentAsync(DepartmentModel departmentModel);

        Task<IEnumerable<DepartmentModel>> GetDepartmentsAsync();

        Task<DepartmentModel> GetDepartmentByIdAsync(int id);
    }
}
