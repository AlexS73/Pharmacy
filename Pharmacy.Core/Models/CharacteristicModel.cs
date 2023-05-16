using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Entity;

namespace Pharmacy.Core.Models
{
    public class CharacteristicModel
    {
        public CharacteristicModel()
        {
            
        }

        public CharacteristicModel(Characteristic characteristic)
        {
            //this.Id = characteristic.Id;
            //this.Type = new CharacteristicTypeModel(characteristic.Type);
            this.TypeId = characteristic.TypeId;
            this.Value = characteristic.Value;
        }
        public CharacteristicTypeModel Type { get; set; }
        public int TypeId { get; set; }
        public string Value { get; set; }
    }
}
