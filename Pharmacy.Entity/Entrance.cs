using System.Collections.Generic;

namespace Pharmacy.Entity
{
    public class Entrance: ProductOperation
    {
        public virtual IEnumerable<EntranceProduct> EntranceProducts { get; set; }
    }
}
