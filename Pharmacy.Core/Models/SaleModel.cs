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
            this.Id = sale.Id;
            this.CreatedOn = sale.CreatedOn;
            this.CreatedBy = sale.User.UserName;
            this.Customer = sale.Customer;
        
            this.SaleProducts = sale.SaleProducts.Select(_ => new SaleProductModel(_)).ToList();
            this.Sum = sale.Sum;
            this.Department = new DepartmentModel(sale.Warehouse.Department);
        }
        public double Sum { get; set; }
        public string Customer { get; set; }
        public ICollection<SaleProductModel> SaleProducts { get; set; }
    }
}
