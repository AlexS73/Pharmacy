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
        Task<IEnumerable<PriceModel>> GetPrices();
        Task<IEnumerable<PriceModel>> GetPricesByDepartment(int departmentId);
        Task<IEnumerable<PriceModel>> SavePrices(PriceModel price);

    }
}
