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
            this.ProductId = saleProduct.ProductId;
            this.Product = new ProductModel(saleProduct.Product);
            this.Count = saleProduct.Count;
        }
        public OperationProductModel(EntranceProduct entrancProduct)
        {
            this.Id = entrancProduct.Id;
            this.ProductId = entrancProduct.ProductId;
            this.Product = new ProductModel(entrancProduct.Product);
            this.Count = entrancProduct.Count;
        }
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
        public int Count { get; set; }
    }

    public class SaleProductModel: OperationProductModel
    {
        public SaleProductModel()
        {
            
        }
        
        public SaleProductModel(SaleProduct saleProduct) : base(saleProduct)
        {
            this.Price = saleProduct.Price;
        }

        public double Price { get; set; }
    }
}
