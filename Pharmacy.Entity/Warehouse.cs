using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Entity
{
    public class Warehouse
    {
        public int Id { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public virtual ICollection<SaleProduct> Sales { get; set; }
        public virtual ICollection<EntranceProduct> Entrances { get; set; }

        public int Stock { get; set; }
    }
}
