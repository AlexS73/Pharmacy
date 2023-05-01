using Pharmacy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models
{
    public class DepartmentModel
    {
        public DepartmentModel()
        {

        }
        public DepartmentModel(Department department)
        {
            Id = department.Id;
            Name = department.Name;
            Address = department.Address;
            if (department.Warehouse != null)
            {
                Warehouse = new WarehouseModel(department.Warehouse);
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public WarehouseModel Warehouse { get; set; }
    }
}
