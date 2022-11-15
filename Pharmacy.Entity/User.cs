using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Entity
{
    public class User: IdentityUser<int>
    {
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
