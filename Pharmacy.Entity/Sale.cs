using System.Collections.Generic;

namespace Pharmacy.Entity
{
    public class Sale: ProductOperation
    {
        public virtual ICollection<SaleProduct> SaleProducts { get; set; }
    }
}
