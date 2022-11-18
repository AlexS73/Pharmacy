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
        Sale CreateSale(SaleModel saleModel, User user);

        Entrance CreateEntrance(EntranceModel entranceModel, User user);
    }
}
