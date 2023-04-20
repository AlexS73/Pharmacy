using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Entity
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual IEnumerable<WarehouseOperation> Operations { get; set; }
        public virtual IEnumerable<ProductStock> ProductStocks { get; set; }
    }
}
