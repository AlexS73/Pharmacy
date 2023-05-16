using System.Collections.Generic;
using System.Threading.Tasks;
using Pharmacy.Core.Models;

namespace Pharmacy.BL.Interfaces
{
    public interface IWarehouseService
    {
        Task<IEnumerable<WarehouseModel>> GetAsync();
        Task<WarehouseModel> SaveAsync(WarehouseModel warehouseModel);
    }
}