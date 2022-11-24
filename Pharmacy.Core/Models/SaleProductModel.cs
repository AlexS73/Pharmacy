using Pharmacy.Entity;

namespace Pharmacy.Core.Models
{
    public class SaleProductModel
    {
        public SaleProductModel()
        {

        }
        public SaleProductModel(SaleProduct saleProduct)
        {
            this.Id = saleProduct.Id;
            this.Product = new ProductModel(saleProduct.Product);
            this.Count = saleProduct.Count;
        }
        public int Id { get; set; }
        public ProductModel Product { get; set; }
        public int Count { get; set; }
    }
}
