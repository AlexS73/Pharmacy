using Microsoft.Extensions.Options;
using Pharmacy.BL.Interfaces;
using Pharmacy.Core.Models;
using Pharmacy.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BL.Services
{
    public class AdministrationService: IAdministrationService
    {
        private readonly PharmacyContext db;
        private readonly HttpClient httpClient;
        private readonly DepartmentSettings departmentSettings;
        private readonly IProductService productService;

        public AdministrationService(PharmacyContext pharmacyContext, IHttpClientFactory httpClientFactory,IProductService productService, IOptions<DepartmentSettings> departmentSettings)
        {
            this.db = pharmacyContext;
            this.httpClient = httpClientFactory.CreateClient();
            this.productService = productService;
            this.departmentSettings = departmentSettings.Value;
        }

        public async Task LoadProductsAsync()
        {
            var uri = departmentSettings.DepartmentUrls["Main"] + "/api/products";

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var result = await httpClient.SendAsync(request);
            var products = await result.Content.ReadFromJsonAsync<IEnumerable<ProductModel>>();

            var existedProducts = db.Products.Select(_=> new ProductModel(_)).ToList();

            var newProducts = existedProducts.Except(products).ToList();

            await productService.SaveProductsAsync(newProducts);
        }

        public async Task<IEnumerable<WarehouseModel>> LoadLeftoversAsync(string department)
        {
            var uri = departmentSettings.DepartmentUrls[department] + "/api/warehouse";

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var result = await httpClient.SendAsync(request);
            var warehouse = await result.Content.ReadFromJsonAsync<IEnumerable<WarehouseModel>>();
            return warehouse;

        }
    }
}
