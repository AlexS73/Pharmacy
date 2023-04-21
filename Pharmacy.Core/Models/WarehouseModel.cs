using Pharmacy.Entity;

namespace Pharmacy.Core.Models
{
    public class WarehouseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentModel Department { get; set; }

        public WarehouseModel(Warehouse warehouse)
        {
            //this.Product = new ProductModel(warehouse.Product);
            //this.Count = warehouse.Stock;
        }


    }
}