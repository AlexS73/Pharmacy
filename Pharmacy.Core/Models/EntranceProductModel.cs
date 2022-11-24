using Pharmacy.Entity;

namespace Pharmacy.Core.Models
{
    public class EntranceProductModel
    {
        public EntranceProductModel()
        {

        }

        public EntranceProductModel(EntranceProduct entranceProduct)
        {
            this.Id = entranceProduct.Id;
            this.Product = new ProductModel(entranceProduct.Product);
            this.Count = entranceProduct.Count;
        }
        public int Id { get; set; }
        public ProductModel Product { get; set; }
        public int Count { get; set; }
    }
}
