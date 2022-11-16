namespace Pharmacy.Core.Models
{
    public class SaleProductModel
    {
        public int Id { get; set; }
        public ProductModel Product { get; set; }
        public int Count { get; set; }
    }
}
