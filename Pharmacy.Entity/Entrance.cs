using System.Collections.Generic;

namespace Pharmacy.Entity
{
    public class Entrance: ProductOperation
    {
        public virtual IEnumerable<EntranceProduct> Products { get; set; }
    }
}
