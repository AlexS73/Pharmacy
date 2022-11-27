using Pharmacy.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Pharmacy.Core.Models
{
    public class SaleModel: ProductOperationModel
    {
        public SaleModel()
        {

        }

        public SaleModel(Sale sale)
        {
            this.Id = sale.Id;
            this.CreatedOn = sale.CreatedOn;
            this.CreatedBy = sale.User.UserName;
            this.SaleProducts = sale.SaleProducts.Select(_ => new SaleProductModel(_)).ToList();
        }
        public IEnumerable<SaleProductModel> SaleProducts { get; set; }
    }
}
