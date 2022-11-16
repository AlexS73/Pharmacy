namespace Pharmacy.Core.Models
{
    public class EntranceProductModel
    {
        public int Id { get; set; }
        public ProductModel Product { get; set; }
        public int Count { get; set; }
    }
}
