using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Pharmacy.Entity;

namespace Pharmacy.Core.Models
{
    public class WarehouseModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        [Required]
        public int DepartmentId { get; set; }

        public WarehouseModel()
        {
            
        }
        public WarehouseModel(Warehouse warehouse)
        {
            this.Id = warehouse.Id;
            this.Name = warehouse.Name;
            this.Address = warehouse.Address;
            this.DepartmentId = warehouse.DepartmentId;
            //this.Department = new DepartmentModel(warehouse.Department);
        }
    }
}