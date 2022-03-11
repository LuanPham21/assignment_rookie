using Newtonsoft.Json;
using RookieShop.ViewModel.Catalog.ProductImages;
using RookieShop.ViewModel.Catalog.Products;
using RookieShop.ViewModel.Common;
using System.Text;

namespace Rookie.CustomerSite.Service
{
    public class ProductService : IProductService
    {
        public async Task<ProductViewModel> GetById(int productId)
        {
            var url = $"https://localhost:5000/api/Products/{productId}";
            return JsonConvert.DeserializeObject<ProductViewModel>(await JsonResponseByGet(url));
        }

        public async Task<List<ProductViewModel>> GetListAsync()
        {
            var url = "https://localhost:5000/api/Products";
            return JsonConvert.DeserializeObject<List<ProductViewModel>>(await JsonResponseByGet(url));
        }

        public async Task<List<ProductViewModel>> GetProductinCategory(int CategoryId)
        {
            var url = "https://localhost:5000/api/Products/paging?CategoryId/{CategoryId}";
            return JsonConvert.DeserializeObject<List<ProductViewModel>>(await JsonResponseByGet(url));
        }

        public async Task<string> JsonResponseByGet(string url)
        {
            var jsonResponse = "";
            try
            {
                using var httpClient = new HttpClient();
                jsonResponse = await httpClient.GetStringAsync(url);
                if (string.IsNullOrEmpty(jsonResponse))
                {
                    throw new Exception("The client product get don't have the data");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"At JsonResponseByGet ProductService: {ex.Message}");
            }

            return jsonResponse;
        }
    }
}