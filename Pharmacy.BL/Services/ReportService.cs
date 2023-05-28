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
    public class ReportService : IReportService
    {
        private readonly PharmacyContext db;

        public ReportService(PharmacyContext db)
        {
            this.db = db;
        }

        public async Task<EntranceReportModel> GenerateEntranceReportAsync(DateTime? from, DateTime? to, int? departmentId)
        {
            var query = db.Entrances
                .Include(_ => _.EntranceProducts)
                .ThenInclude(_ => _.Product)
                .Include(_=>_.Warehouse)
                .AsQueryable();

            if (from != null)
                query = query.Where(e => e.CreatedOn >= from);
            

            if (to != null)
                query = query.Where(e => e.CreatedOn >= from);


            if (departmentId != null)
                query = query.Where(e => e.Warehouse.DepartmentId >= departmentId);

            var result = await query.ToListAsync();

            var report = new EntranceReportModel
            {
                GeneratedOn = DateTime.Now,
                From = from ?? DateTime.MinValue,
                To = to ?? DateTime.MaxValue,
                Rows = new List<EntranceReportRowModel>()
            };

            var allProducts = await db.Products.AsNoTracking().ToListAsync();

            foreach (var entrance in result)
            {
                foreach (var entranceProduct in entrance.EntranceProducts)
                {

                    var product = allProducts.FirstOrDefault(p => p.Id == entranceProduct.ProductId);
                    if (product != null)
                    {

                        var row = report.Rows.FirstOrDefault(r => r.Product.Id == product.Id);
                        if (row != null)
                        {

                            row.Count += entranceProduct.Count;
                        }
                        else
                        {

                            report.Rows.Add(new EntranceReportRowModel
                            {
                                Product = new ProductModel
                                {
                                    Id = product.Id,
                                    Name = product.Name
                                },
                                Count = entranceProduct.Count
                            });
                        }
                    }
                }
            }

            return report;
        }

        public async Task<SaleReportModel> GenerateSaleReportAsync(DateTime? from, DateTime? to, int? departmentId)
        {
            var query = db.Sales
            .Include(_ => _.SaleProducts)
            .ThenInclude(_ => _.Product)
            .AsQueryable();

            if (from != null)
            {
                query = query.Where(e => e.CreatedOn >= from);
            }

            if (to != null)
            {
                query = query.Where(e => e.CreatedOn >= from);
            }

            var result = await query.ToListAsync();

            var report = new SaleReportModel
            {
                GeneratedOn = DateTime.Now,
                From = from ?? DateTime.MinValue,
                To = to ?? DateTime.MaxValue,
                Rows = new List<SaleReportRowModel>()
            };

            var allProducts = await db.Products.AsNoTracking().ToListAsync();

            foreach (var sale in result)
            {
                foreach (var saleProduct in sale.SaleProducts)
                {

                    var product = allProducts.FirstOrDefault(p => p.Id == saleProduct.ProductId);
                    if (product != null)
                    {

                        var row = report.Rows.FirstOrDefault(r => r.Product.Id == product.Id);
                        if (row != null)
                        {

                            row.Count += saleProduct.Count;
                            row.Sum += saleProduct.Price;
                        }
                        else
                        {

                            report.Rows.Add(new SaleReportRowModel
                            {
                                Product = new ProductModel
                                {
                                    Id = product.Id,
                                    Name = product.Name
                                },
                                Count = saleProduct.Count,
                                Sum = saleProduct.Price
                            });
                        }
                    }
                }
            }

            return report;
        }
    }
}
