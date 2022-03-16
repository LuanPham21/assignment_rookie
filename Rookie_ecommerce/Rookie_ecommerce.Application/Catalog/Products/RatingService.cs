using RookieShop.Data.EF;
using RookieShop.Data.Entities;
using RookieShop.ViewModel.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie_ecommerce.Application.Catalog.Products
{
    public class RatingService : IRatingService
    {
        private readonly EcommerceDbContext _context;

        public RatingService(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<int> InsertRating(RatingVM request)
        {
            var rate = new Rate()
            {
                Rating = request.Rating,
                Description = request.Description,
                ProductId = request.ProductId,
                UserId = request.UserId,
            };
            _context.Rates.Add(rate);
            await _context.SaveChangesAsync();
            return rate.Id;
        }
    }
}