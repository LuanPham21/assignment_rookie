using Newtonsoft.Json;
using RookieShop.ViewModel.Catalog.Products;

namespace Rookie.CustomerSite.Service
{
    public class RatingService : IRatingService
    {
        public async Task<int> InsertRating(RatingVM request)
        {
            var url = $"https://localhost:5000/api/Rating?Rating={request.Rating}&Description={request.Description}&ProductId={request.ProductId}&UserId={request.UserId}";
            return JsonConvert.DeserializeObject<int>(await JsonResponseByGet(url));
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