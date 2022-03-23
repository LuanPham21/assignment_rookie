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

        public async Task<List<RatingVM>> GetByProduct(int productId)
        {
            var query = from r in _context.Rates
                        where r.ProductId == productId
                        select new { r };
            List<RatingVM> listvm = new List<RatingVM>();
            foreach (var rate in query)
            {
                var ratingViewModel = new RatingVM()
                {
                    Rating = rate.r.Rating,
                    Description = rate.r.Description,
                    ProductId = rate.r.ProductId,
                    UserId = rate.r.UserId
                };

                listvm.Add(ratingViewModel);
            }
            return listvm;
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