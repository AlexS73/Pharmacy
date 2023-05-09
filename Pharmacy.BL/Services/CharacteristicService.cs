using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pharmacy.BL.Interfaces;
using Pharmacy.Core.Models;
using Pharmacy.Entity;

namespace Pharmacy.BL.Services
{
    public class CharacteristicService : ICharacteristicService
    {
        private readonly PharmacyContext db;
        public CharacteristicService(PharmacyContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CharacteristicTypeModel>> GetTypes()
        {
            return await db.CharacteristicTypes.AsNoTracking().Select(_ => new CharacteristicTypeModel(_)).ToListAsync();
        }

        public async Task<CharacteristicTypeModel> SaveType(CharacteristicTypeModel type)
        {
            if (type.Id == 0)
            {
                var newCharType = new CharacteristicType()
                {
                    Name = type.Name
                };

                db.CharacteristicTypes.Add(newCharType);

                await db.SaveChangesAsync();
                return new CharacteristicTypeModel(newCharType);
            }

            var dbCharType = await db.CharacteristicTypes.FindAsync(type.Id);

            dbCharType.Name = type.Name;
            await db.SaveChangesAsync();
            return new CharacteristicTypeModel(dbCharType);
        }
    }
}
