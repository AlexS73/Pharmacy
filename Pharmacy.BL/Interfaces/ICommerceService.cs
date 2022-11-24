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
    }
}
