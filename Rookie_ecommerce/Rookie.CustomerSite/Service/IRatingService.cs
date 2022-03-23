using RookieShop.ViewModel.Catalog.Products;

namespace Rookie.CustomerSite.Service
{
    public interface IRatingService
    {
        public Task<int> InsertRating(RatingVM request);

        public Task<List<RatingVM>> GetByProduct(int productId);
    }
}