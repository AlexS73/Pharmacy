using Microsoft.AspNetCore.Identity;
using Pharmacy.BL.Interfaces;
using Pharmacy.Core.Models;
using Pharmacy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Pharmacy.BL.Services
{
    public class CommerceService : ICommerceService
    {
        private readonly PharmacyContext db;

        public CommerceService(PharmacyContext db)
        {
            this.db = db;
        }
        
        public async Task<IEnumerable<SaleModel>> GetSales()
        {
            var result = await this.db.Sales
                .Include(_=>_.User)
                .Include(_=>_.SaleProducts)
                .ThenInclude(_=>_.Product)
                .Select(_=> new SaleModel(_)).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<EntranceModel>> GetEntrances()
        {
            var result = await this.db.Entrances
                .Include(_=>_.User)
                .Include(_=>_.EntranceProducts)
                .ThenInclude(_=>_.Product)
                .Select(_=> new EntranceModel(_)).ToListAsync();
            return result;
        }
        
        public async Task<SaleModel> GetSaleById(int id)
        {
            var result = await db.Sales
                .Include(_=>_.User)
                .Include(_=>_.SaleProducts)
                .ThenInclude(_=>_.Product)
                .FirstOrDefaultAsync(_=>_.Id == id);
            
            return new SaleModel(result);
        }

        public async Task<EntranceModel> GetEntranceById(int id)
        {
            var result = await db.Entrances
                .Include(_=>_.User)
                .Include(_=>_.EntranceProducts)
                .ThenInclude(_=>_.Product)
                .FirstOrDefaultAsync(_=>_.Id == id);
            return new EntranceModel(result);
        }
        
        public async Task<EntranceModel> CreateEntranceAsync(EntranceModel entranceModel, User user)
        {
            var newEntrance = new Entrance()
            {
                CreatedOn = DateTime.UtcNow,
                EntranceProducts = entranceModel.EntranceProducts.Select(_ => new EntranceProduct()
                {
                    Count = _.Count,
                    ProductId = _.Product.Id,
                }).ToList(),
                User = user
            };

            var newOperations = entranceModel.EntranceProducts.Select(_ => new WarehouseOperation() {
                ProductId = _.Product.Id,
                Operation = newEntrance,
            });

            //db.Entrances.Add(newEntrance);
            db.WarehouseOperations.AddRange(newOperations);
            await db.SaveChangesAsync();

            return new EntranceModel(newEntrance);
        }
        
        public async Task<SaleModel> CreateSaleAsync(SaleModel saleModel, User user)
        {
            var newSale = new Sale()
            {
                CreatedOn = DateTime.UtcNow,
                SaleProducts = saleModel.SaleProducts.Select(_ => new SaleProduct()
                {
                    Count = _.Count,
                    ProductId = _.Product.Id,
                }).ToList(),
                User = user
            };

            var newOperations = saleModel.SaleProducts.Select(_ => new WarehouseOperation()
            {
                ProductId = _.Product.Id,
                Operation = newSale,
            });

            db.Sales.Add(newSale);
            db.WarehouseOperations.AddRange(newOperations);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            

            return new SaleModel(newSale);
        }
    }
}
