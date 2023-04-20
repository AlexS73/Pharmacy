using System.Collections.Generic;

namespace Pharmacy.Entity
{
    public class Characteristic
    {
        public int Id { get; set; }
        public CharacteristicType Type { get; set; }
        public string Value { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }

    public enum CharacteristicType
    {
        Category = 1,
        ExpirationDate = 2
    }
}