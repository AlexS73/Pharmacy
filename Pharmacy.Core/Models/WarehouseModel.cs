using Pharmacy.Entity;

namespace Pharmacy.Core.Models
{
    public class WarehouseModel
    {
        public WarehouseModel(Warehouse warehouse)
        {
            this.Product = new ProductModel(warehouse.Product);
            this.Count = warehouse.Stock;
        }
        public ProductModel Product { get; set; }
        public int Count { get; set; }
    }
}