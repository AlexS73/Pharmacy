using Pharmacy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BL.Interfaces
{
    public interface IAdministrationService
    {
        public Task LoadProductsAsync();

        public Task<IEnumerable<WarehouseModel>> LoadLeftoversAsync(string department);
    }
}
