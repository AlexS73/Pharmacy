using Pharmacy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models
{
    public class PriceModel
    {
        public PriceModel(ProductPrice price)
        {
            this.Id = price.Id;
            this.ProductId = price.ProductId;
            this.Price = price.Price;
            this.WarehouseId = price.WarehouseId;
        }
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public decimal Price { get; set; }
    }
}
