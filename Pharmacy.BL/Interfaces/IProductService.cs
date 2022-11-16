using Pharmacy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BL.Interfaces
{
    public interface IProductService
    {
        Task CreateProdut(ProductModel product);
        Task CreateProducts(IEnumerable<ProductModel> products);
        IEnumerable<ProductModel> GetAllProducts();
    }
}
