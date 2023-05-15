using Pharmacy.Core.Models;
using Pharmacy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BL.Interfaces
{
    public interface ICommerceService
    {
        Task<SaleModel> CreateSaleAsync(SaleModel saleModel, User user);
        Task<EntranceModel> CreateEntranceAsync(EntranceModel entranceModel, User user);
        Task<IEnumerable<SaleModel>> GetSales();
        Task<IEnumerable<SaleModel>> GetSalesByDepartment(int departmentId);
        Task<IEnumerable<EntranceModel>> GetEntrances();
        Task<IEnumerable<EntranceModel>> GetEntrancesByDepartment(int departmentId);
        Task<SaleModel> GetSaleById(int id);
        Task<EntranceModel> GetEntranceById(int id);
    }
}
