using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models
{
    public class EntranceReportModel
    {
        public DateTime GeneratedOn { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public ICollection<EntranceReportRowModel> Rows { get; set; }
    }

    public class EntranceReportRowModel
    {
        public ProductModel Product { get; set; }
        public int Count { get; set; }
    }
}
