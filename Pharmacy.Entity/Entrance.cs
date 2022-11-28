using System.Collections.Generic;

namespace Pharmacy.Entity
{
    public class Entrance: ProductOperation
    {
        public virtual ICollection<EntranceProduct> EntranceProducts { get; set; }
    }
}
