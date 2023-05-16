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
                .Include(_=>_.Warehouse)
                .ThenInclude(_=>_.Department)
                .Select(_=> new SaleModel(_)).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<SaleModel>> GetSalesByDepartment(int departmentId)
        {
            var result = await this.db.Sales
                .Include(_ => _.User)
                .Include(_ => _.SaleProducts)
                .ThenInclude(_ => _.Product)
                .Include(_=>_.Warehouse)
                .ThenInclude(_=>_.Department)
                .Where(_=>_.Warehouse.DepartmentId == departmentId)
                .Select(_ => new SaleModel(_))
                .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<EntranceModel>> GetEntrances()
        {
            var result = await this.db.Entrances
                .Include(_=>_.User)
                .Include(_=>_.EntranceProducts)
                .ThenInclude(_=>_.Product)
                .Include(_ => _.Warehouse)
                .ThenInclude(_ => _.Department)
                .Select(_=> new EntranceModel(_)).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<EntranceModel>> GetEntrancesByDepartment(int departmentId)
        {
            var result = await this.db.Entrances
                .Include(_ => _.User)
                .Include(_ => _.EntranceProducts)
                .ThenInclude(_ => _.Product)
                .Include(_ => _.Warehouse)
                .ThenInclude(_=>_.Department)
                .Where(_ => _.Warehouse.DepartmentId == departmentId)
                .Select(_ => new EntranceModel(_)).ToListAsync();
            return result;
        }

        public async Task<SaleModel> GetSaleById(int id)
        {
            var result = await db.Sales
                .Include(_=>_.User)
                .Include(_=>_.SaleProducts)
                .ThenInclude(_=>_.Product)
                .Include(_ => _.Warehouse)
                .ThenInclude(_ => _.Department)
                .FirstOrDefaultAsync(_=>_.Id == id);
            
            return new SaleModel(result);
        }

        public async Task<EntranceModel> GetEntranceById(int id)
        {
            var result = await db.Entrances
                .Include(_=>_.User)
                .Include(_=>_.EntranceProducts)
                .ThenInclude(_=>_.Product)
                .Include(_ => _.Warehouse)
                .ThenInclude(_ => _.Department)
                .FirstOrDefaultAsync(_=>_.Id == id);
            return new EntranceModel(result);
        }
        
        public async Task<EntranceModel> CreateEntranceAsync(EntranceModel entranceModel, User user)
        {
            try
            {
                if (entranceModel.EntranceProducts.Any(e => e.Count <= 0))
                {
                    throw new ArgumentException("Count can not be less or equal 0");
                }
                var warehouse = await db.Warehouse.FirstAsync(_ => _.DepartmentId == user.DepartmentId);
                var newEntrance = new Entrance()
                {
                    CreatedOn = DateTime.UtcNow,
                    Supplier = entranceModel.Supplier,
                    User = user,
                    Warehouse = warehouse,
                    EntranceProducts = entranceModel.EntranceProducts.Select(_ => new EntranceProduct()
                    {
                        ProductId = _.ProductId,
                        Count = _.Count
                    }).ToList()
                };

                db.Entrances.Add(newEntrance);

                var newStocks = newEntrance.EntranceProducts.Select(_ => new ProductStock()
                {
                    ProductId = _.ProductId,
                    WarehouseId = warehouse.Id,
                    Count = _.Count
                }).ToList();

                var dbStocks = await db.ProductStocks
                    .Where(_ => newEntrance.EntranceProducts.Select(p => p.ProductId).Contains(_.ProductId) && _.WarehouseId == warehouse.Id)
                    .ToListAsync();


                foreach (var newStock in newStocks)
                {
                    var dbStock = dbStocks
                        .FirstOrDefault(_ => _.ProductId == newStock.ProductId && _.WarehouseId == newStock.WarehouseId);

                    if (dbStock != null)
                    {
                        dbStock.Count += newStock.Count;
                    }
                    else
                    {
                        db.ProductStocks.Add(newStock);
                    }
                }

                await db.SaveChangesAsync();
                var result = await db.Entrances
                    .Include(_=>_.EntranceProducts)
                    .ThenInclude(_=>_.Product)
                    .Include(_=>_.User)
                    .Include(_ => _.Warehouse)
                    .ThenInclude(_ => _.Department)
                    .AsNoTracking()
                    .FirstAsync(_=> _.Id == newEntrance.Id);
                return new EntranceModel(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<SaleModel> CreateSaleAsync(SaleModel saleModel, User user)
        {

            if (saleModel.SaleProducts.Any(e => e.Count <= 0))
            {
                throw new ArgumentException("Количество товара не может быть меньше 0!");
            }
            var warehouse = await db.Warehouse.FirstAsync(_ => _.DepartmentId == user.DepartmentId);
            var newSale = new Sale()
            {
                CreatedOn = DateTime.UtcNow,
                Customer = saleModel.Customer,
                User = user,
                Warehouse = warehouse,
                SaleProducts = saleModel.SaleProducts.Select(_ => new SaleProduct()
                {
                    ProductId = _.ProductId,
                    Count = _.Count,
                    Price = _.Price
                }).ToList()
            };

            db.Sales.Add(newSale);

            var newStocks = newSale.SaleProducts.Select(_ => new ProductStock()
            {
                ProductId = _.ProductId,
                WarehouseId = warehouse.Id,
                Count = _.Count
            }).ToList();

            var dbStocks = await db.ProductStocks
                .Include(_=>_.Product)
                .Where(_ => newSale.SaleProducts.Select(p => p.ProductId).Contains(_.ProductId) && _.WarehouseId == warehouse.Id)
                .ToListAsync();


            foreach (var newStock in newStocks)
            {
                var dbStock = dbStocks
                    .FirstOrDefault(_ => _.ProductId == newStock.ProductId && _.WarehouseId == newStock.WarehouseId);

                if (dbStock != null)
                {
                    dbStock.Count -= newStock.Count;
                    if (dbStock.Count < 0)
                    {
                        throw new ArgumentException($"Недостаточно товара - {dbStock.Product.Name}; Остаток: {dbStock.Count + newStock.Count}");
                    }
                }
                else
                {
                    db.ProductStocks.Add(newStock);
                }
            }

            await db.SaveChangesAsync();
            var result = await db.Sales
                .Include(_ => _.SaleProducts)
                .ThenInclude(_ => _.Product)
                .Include(_ => _.User)
                .Include(_ => _.Warehouse)
                .ThenInclude(_ => _.Department)
                .AsNoTracking()
                .FirstAsync(_ => _.Id == newSale.Id);
            return new SaleModel(result);

        }
    }
}
