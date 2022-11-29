using System;
using Pharmacy.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Pharmacy.Core.Models
{
    public class SaleModel: OperationModel
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
                this.Customer = sale.Customer;
            
                this.SaleProducts = sale.SaleProducts.Select(_ => new OperationProductModel(_)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        public string Customer { get; set; }
        public ICollection<OperationProductModel> SaleProducts { get; set; }
    }
}
