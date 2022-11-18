using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models
{
    public class EntranceModel
    {
        public IEnumerable<EntranceProductModel> EntranceProducts { get; set; }
    }
}
