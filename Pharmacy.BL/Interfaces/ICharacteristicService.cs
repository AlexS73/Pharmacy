using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Core.Models;

namespace Pharmacy.BL.Interfaces
{
    public interface ICharacteristicService
    {
        Task<IEnumerable<CharacteristicTypeModel>> GetTypes();
        Task<CharacteristicTypeModel> SaveType(CharacteristicTypeModel type);

    }
}
