using System.Collections.Generic;

namespace Pharmacy.Entity
{
    public class Characteristic
    {
        public int Id { get; set; }
        public virtual CharacteristicType Type { get; set; }
        public int TypeId { get; set; }
        public string Value { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }

    public class CharacteristicType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}