using Pharmacy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BL.Interfaces
{
    public interface IPriceService
    {
        Task<IEnumerable<ProductPriceModel>> GetPrices();
        Task<IEnumerable<ProductPriceModel>> GetPricesByDepartment(int departmentId);
        Task<ProductPriceModel> Save(ProductPriceModel price);
        Task<IEnumerable<ProductPriceModel>> SavePrices(ProductPriceModel price);

    }
}
