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
        Task<ProductModel> SaveProductAsync(ProductModel product);
        Task<IEnumerable<ProductModel>> SaveProductsAsync(IEnumerable<ProductModel> products);
        Task<IEnumerable<ProductModel>> GetAllProductsAsync();
        Task<ProductModel> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductViewModel>> GetViewProducts(int departmentId);
        Task<IEnumerable<string>> GetCategories();
    }
}
