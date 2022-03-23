using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rookie.CustomerSite.Service;
using Rookie_ecommerce.Application.Catalog.Categories;
using RookieShop.ViewModel.Catalog.Products;

namespace Rookie.CustomerSite.Controllers
{
    public class RatingController : Controller
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        public IActionResult Index(string rating, string comment, string productId)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                RatingVM rate = new RatingVM();
                rate.Rating = int.Parse(rating);
                rate.Description = comment;
                rate.ProductId = int.Parse(productId);
                rate.UserId = Guid.Parse(User.Claims.Where(m => m.Type == "id").SingleOrDefault().Value.ToString());
                _ratingService.InsertRating(rate);
                return Redirect("/Detail/" + productId);
            }
            else
            {
                return Redirect("/user/login");
            }
        }
    }
}