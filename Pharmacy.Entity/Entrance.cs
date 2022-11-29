using System.Collections.Generic;

namespace Pharmacy.Entity
{
    public class Entrance: ProductOperation
    {
        public string Supplier { get; set; }
        public virtual ICollection<EntranceProduct> EntranceProducts { get; set; }
    }
    public class EntranceProduct
    {
        public int Id { get; set; }
        public virtual Entrance Entrance { get; set; }
        public int EntranceId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public int Count { get; set; }
    }
}
