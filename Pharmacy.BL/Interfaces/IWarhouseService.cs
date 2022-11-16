using Pharmacy.Core.Models;
using Pharmacy.Entity;
using System.Collections.Generic;

namespace Pharmacy.BL.Interfaces
{
    interface IWarhouseService
    {
        IEnumerable<Warehouse> GetLeftovers();

    }
}
