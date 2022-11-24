using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models
{
    public class DepartmentSettings
    {
        public string CurrentDepartment { get; set; }

        public IDictionary<string, string> DepartmentUrls { get; set; }
    }
}
