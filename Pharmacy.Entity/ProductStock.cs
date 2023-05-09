namespace Pharmacy.Entity
{
    public class ProductStock
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse{ get; set; }
        public int Count { get; set; }
    }
}