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
            throw new NotImplementedException();
            //try
            //{
            //    var productsDb = db.Products
            //    .Include(_ => _.Warehouse)
            //    .Where(_ => entranceModel.EntranceProducts.Select(sp => sp.Product.Id).Contains(_.Id))
            //    .ToList();

            //    List<EntranceProduct> productsForEntrance = new();
            //    foreach (var sp in entranceModel.EntranceProducts)
            //    {
            //        var productDb = productsDb.FirstOrDefault(_ => _.Id == sp.Product.Id);
            //        if (productDb == null)
            //        {
            //            throw new ArgumentNullException($"Product not found; Id: {sp.Product.Id}");
            //        }
            //        if (productDb.Warehouse == null)
            //        {
            //            productDb.Warehouse = new Warehouse();
            //        }
            //        //CheckStock(productDb, sp);

            //        productDb.Warehouse.Stock += sp.Count;
            //        productsForEntrance.Add(new EntranceProduct
            //        {
            //            Count = sp.Count,
            //            ProductId = sp.Product.Id,
            //            Warehouse = productDb.Warehouse
            //        });
            //    }

            //    var newEntrance = new Entrance()
            //    {
            //        CreatedOn = DateTime.UtcNow,
            //        EntranceProducts = productsForEntrance,
            //        User = user,
            //        Supplier = entranceModel.Supplier,
            //    };

            //    db.Entrances.Add(newEntrance);

            //    await db.SaveChangesAsync();
            //    return new EntranceModel(newEntrance);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    throw;
            //}
        }

        public async Task<SaleModel> CreateSaleAsync(SaleModel saleModel, User user)
        {
            throw new NotImplementedException();
            //try
            //{
            //    var productsDb = db.Products
            //    .Include(_ => _.Warehouse)
            //    .Where(_ => saleModel.SaleProducts.Select(sp => sp.Product.Id).Contains(_.Id))
            //    .ToList();

            //    List <SaleProduct> productsForSale = new();
            //    foreach (var sp in saleModel.SaleProducts)
            //    {
            //        var productDb = productsDb.FirstOrDefault(_ => _.Id == sp.Product.Id);
            //        if (productsDb == null)
            //        {
            //            throw new ArgumentNullException($"Product not found; Id: {sp.Product.Id}");
            //        }
            //        CheckStock(productDb, sp);

            //        productDb.Warehouse.Stock -= sp.Count;
            //        productsForSale.Add(new SaleProduct {
            //            Count = sp.Count,
            //            ProductId = sp.Product.Id,
            //            Warehouse = productDb.Warehouse,
            //        });
            //    }

            //    var newSale = new Sale()
            //    {
            //        CreatedOn = DateTime.UtcNow,
            //        SaleProducts = productsForSale,
            //        User = user,
            //        Customer = saleModel.Customer
            //    };

            //    db.Sales.Add(newSale);

            //    await db.SaveChangesAsync();
            //    return new SaleModel(newSale);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    throw;
            //}
            
        }

        private void CheckStock(Product product, OperationProductModel productOperation)
        {
            throw new NotImplementedException();
            //if (product.Warehouse == null)
            //{
            //    throw new ArgumentNullException($"Product doesn't have warehouse; Id: {product.Id}");
            //}
            //if (product.Warehouse.Stock < productOperation.Count)
            //{
            //    throw new ArgumentNullException($"Product is not enough in the balance; Id: {product.Id}");
            //}
        }
    }
}
