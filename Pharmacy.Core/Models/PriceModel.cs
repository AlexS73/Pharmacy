using Pharmacy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace Pharmacy.Core.Models
{
    public class ProductPriceModel
    {
        public ProductPriceModel()
        {
            
        }
        public ProductPriceModel(ProductPrice price)
        {
            this.Id = price.Id;
            this.ProductId = price.ProductId;
            this.Product = new ProductModel(price.Product);
            this.Price = price.Price;
            this.WarehouseId = price.WarehouseId;
            this.Warehouse = new WarehouseModel(price.Warehouse);
        }
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
        public int WarehouseId { get; set; }
        public WarehouseModel Warehouse { get; set; }
        public decimal Price { get; set; }
    }
}
