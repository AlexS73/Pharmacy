using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Entity
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public string Address { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
