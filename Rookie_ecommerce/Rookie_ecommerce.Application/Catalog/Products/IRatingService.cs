using RookieShop.ViewModel.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie_ecommerce.Application.Catalog.Products
{
    public interface IRatingService
    {
        Task<int> InsertRating(RatingVM request);

        Task<List<RatingVM>> GetByProduct(int productId);
    }
}