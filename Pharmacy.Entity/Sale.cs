using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Entity
{
    public class Sale: WarehouseOperation
    {
        public string Customer { get; set; }
        public virtual IEnumerable<SaleProduct> SaleProducts { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public double Sum { get; set; }
    }
    public class SaleProduct
    {
        public int Id { get; set; }
        public virtual Sale Sale { get; set; }
        public int SaleId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public double Price { get; set; }
    }
}
