using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Entity
{
    public class ProductPrice
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
