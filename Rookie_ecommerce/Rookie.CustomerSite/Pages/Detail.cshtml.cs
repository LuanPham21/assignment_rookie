using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rookie.CustomerSite.Service;
using RookieShop.ViewModel.Catalog.Products;

namespace Rookie.CustomerSite.Pages
{
    public class DetailModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IRatingService _ratingService;

        public DetailModel(IProductService productService,
            IRatingService ratingService)
        {
            _productService = productService;
            _ratingService = ratingService;
        }

        public ProductViewModel Product { get; set; }
        public List<RatingVM> Rating { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ProductId { get; set; }

        public async Task OnGet()
        {
            Product = await _productService.GetById(ProductId);
            Rating = await _ratingService.GetByProduct(ProductId);
        }
    }
}