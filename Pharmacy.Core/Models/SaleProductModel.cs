using Pharmacy.Entity;

namespace Pharmacy.Core.Models
{
    public class OperationProductModel
    {
        public OperationProductModel()
        {

        }
        public OperationProductModel(SaleProduct saleProduct)
        {
            this.Id = saleProduct.Id;
            this.Product = new ProductModel(saleProduct.Product);
            this.Count = saleProduct.Count;
        }
        public OperationProductModel(EntranceProduct entrancProduct)
        {
            this.Id = entrancProduct.Id;
            this.Product = new ProductModel(entrancProduct.Product);
            this.Count = entrancProduct.Count;
        }
        public int Id { get; set; }
        public ProductModel Product { get; set; }
        public int Count { get; set; }
    }
}
