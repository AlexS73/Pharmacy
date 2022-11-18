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
                EntranceProducts = entranceModel.EntranceProducts.Select(_ => new EntranceProduct()
                {
                    Count = _.Count,
                    ProductId = _.Product.Id,
                }),
                User = user
            };

            var newOperations = entranceModel.EntranceProducts.Select(_ => new WarehouseOperation() {
                ProductId = _.Product.Id,
                Operation = newEntrance,
            });

            //db.Entrances.Add(newEntrance);
            db.WarehouseOperations.AddRange(newOperations);
            db.SaveChanges();

            return newEntrance;
        }

        public Sale CreateSale(SaleModel saleModel, User user)
        {
            var newSale = new Sale()
            {
                CreatedOn = DateTime.UtcNow,
                SaleProducts = saleModel.SaleProducts.Select(_ => new SaleProduct()
                {
                    Count = _.Count,
                    ProductId = _.Product.Id,
                }),
                User = user
            };

            var newOperations = saleModel.SaleProducts.Select(_ => new WarehouseOperation()
            {
                ProductId = _.Product.Id,
                Operation = newSale,
            });

            //db.Sales.Add(newSale);
            db.WarehouseOperations.AddRange(newOperations);
            db.SaveChanges();

            return newSale;
        }
    }
}
