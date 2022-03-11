using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RookieShop.ViewModel.Catalog.Categories;

namespace Rookie.CustomerSite.Service
{
    public class CategoryService : ICategorySevice
    {
        public async Task<List<CategoryVm>> GetAll()
        {
            var url = "https://localhost:5000/api/Categories";
            return JsonConvert.DeserializeObject<List<CategoryVm>>(await JsonResponseByGet(url));
        }

        public async Task<CategoryVm> GetById(int id)
        {
            var url = $"https://localhost:5000/api/Categories/{id}";
            return JsonConvert.DeserializeObject<CategoryVm>(await JsonResponseByGet(url));
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