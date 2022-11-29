using Pharmacy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models
{
    public class EntranceModel: OperationModel
    {
        public EntranceModel()
        {

        }
        public EntranceModel(Entrance entrance)
        {
            this.Id = entrance.Id;
            this.CreatedOn = entrance.CreatedOn;
            this.CreatedBy = entrance.User.UserName;
            this.EntranceProducts = entrance.EntranceProducts.Select(_ => new OperationProductModel(_)).ToList();
            this.Supplier = entrance.Supplier;
        }
        public ICollection<OperationProductModel> EntranceProducts { get; set; }
        public string Supplier { get; set; }
    }
}
