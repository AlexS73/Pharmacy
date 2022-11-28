using Pharmacy.Entity;

namespace Pharmacy.Core.Models
{
    public class WarehouseModel
    {

        public WarehouseModel(Warehouse warehouse)
        {
            this.Id = warehouse.Id;
            this.Product = new ProductModel(warehouse.Product);
            this.Count = warehouse.Count;
        }
        public int Id { get; set; }
        public ProductModel Product { get; set; }
        public int Count { get; set; }
    }
}