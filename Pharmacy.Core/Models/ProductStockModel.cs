using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Entity;

namespace Pharmacy.Core.Models
{
    public class ProductStockModel
    {

        public ProductStockModel()
        {
            
        }

        public ProductStockModel(ProductStock productStock)
        {
            this.Id = productStock.Id;
            this.ProductId = productStock.ProductId;
            this.Product = new ProductModel(productStock.Product);
            this.WarehouseId = productStock.WarehouseId;
            this.Warehouse = new WarehouseModel(productStock.Warehouse);
            this.Count = productStock.Count;
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
        public int WarehouseId { get; set; }
        public WarehouseModel Warehouse { get; set; }
        public int Count { get; set; }
    }
}
