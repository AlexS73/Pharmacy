using System;
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
            try
            {
                this.Id = sale.Id;
                this.CreatedOn = sale.CreatedOn;
                this.CreatedBy = sale.User.UserName;
            
                this.SaleProducts = sale.SaleProducts.Select(_ => new SaleProductModel(_)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        public ICollection<SaleProductModel> SaleProducts { get; set; }
    }
}
