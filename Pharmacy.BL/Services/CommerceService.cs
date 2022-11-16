using Microsoft.AspNetCore.Identity;
using Pharmacy.BL.Interfaces;
using Pharmacy.Core.Models;
using Pharmacy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BL.Services
{
    public class CommerceService : ICommerceService
    {
        private readonly PharmacyContext db;

        public CommerceService(PharmacyContext db)
        {
            this.db = db;
        }

        public Entrance CreateEntrance(EntranceModel entranceModel, User user)
        {
            var newEntrance = new Entrance()
            {
                CreatedOn = DateTime.UtcNow,
                EntranceProducts = entranceModel.Products.Select(_ => new EntranceProduct()
                {
                    Count = _.Count,
                    ProductId = _.Id,
                }),
                User = user
            };

            db.Entrances.Add(newEntrance);
            db.SaveChanges();

            return newEntrance;
        }

        public Sale CreateSale(SaleModel saleModel)
        {
            throw new NotImplementedException();
        }
    }
}
