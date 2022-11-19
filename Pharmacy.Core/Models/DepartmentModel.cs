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
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
