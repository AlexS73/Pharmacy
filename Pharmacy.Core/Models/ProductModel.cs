using Pharmacy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models
{
    public class ProductModel
    {
        public ProductModel()
        {

        }

        public ProductModel(Product product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.Article = product.Article;
            this.Description = product.Description;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public string Description { get; set; }
        public IEnumerable<CharacteristicModel> Characteristics { get; set; }
    }
}
