using System.Collections.Generic;

namespace Pharmacy.Entity
{
    public class Sale: ProductOperation
    {
        public virtual IEnumerable<SaleProduct> Products { get; set; }
    }
}
