using System.Collections.Generic;

namespace Pharmacy.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ProductPrice> Prices { get; set; }
        public virtual ICollection<Characteristic> Characteristics { get; set; }
    }
}
