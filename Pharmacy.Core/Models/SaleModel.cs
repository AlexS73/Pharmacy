using System.Collections.Generic;

namespace Pharmacy.Core.Models
{
    public class SaleModel
    {
        public IEnumerable<SaleProductModel> SaleProducts { get; set; }
    }
}
