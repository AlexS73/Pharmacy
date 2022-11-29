using System.Collections.Generic;

namespace Pharmacy.Entity
{
    public class Sale: ProductOperation
    {
        public string Customer { get; set; }
        public virtual ICollection<SaleProduct> SaleProducts { get; set; }
    }
    public class SaleProduct
    {
        public int Id { get; set; }
        public virtual Sale Sale { get; set; }
        public int SaleId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public int Count { get; set; }
    }
}
