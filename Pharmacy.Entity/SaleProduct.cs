namespace Pharmacy.Entity
{
    public class SaleProduct
    {
        public int Id { get; set; }
        public virtual Sale Sale { get; set; }
        public int SaleId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
