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
            
                this.SaleProducts = sale.SaleProducts.Select(_ => new SaleProductModel(_)).ToList();
                this.Sum = sale.Sum;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        public double Sum { get; set; }
        public string Customer { get; set; }
        public ICollection<SaleProductModel> SaleProducts { get; set; }
    }
}
