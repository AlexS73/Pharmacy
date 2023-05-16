using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Entity;

namespace Pharmacy.Core.Models
{
    public class CharacteristicTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CharacteristicTypeModel()
        {
            
        }

        public CharacteristicTypeModel(CharacteristicType characteristicType)
        {
            this.Id = characteristicType.Id;
            this.Name = characteristicType.Name;
        }
    }
}
