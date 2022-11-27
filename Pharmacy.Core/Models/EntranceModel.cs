using Pharmacy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models
{
    public class EntranceModel: ProductOperationModel
    {
        public EntranceModel()
        {

        }
        public EntranceModel(Entrance entrance)
        {
            this.Id = entrance.Id;
            this.CreatedOn = entrance.CreatedOn;
            this.CreatedBy = entrance.User.UserName;
            this.EntranceProducts = entrance.EntranceProducts.Select(_ => new EntranceProductModel(_));
        }
        public IEnumerable<EntranceProductModel> EntranceProducts { get; set; }
    }
}
