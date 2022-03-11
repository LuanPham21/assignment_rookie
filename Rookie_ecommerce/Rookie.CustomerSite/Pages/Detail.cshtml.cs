using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rookie.CustomerSite.Service;
using RookieShop.ViewModel.Catalog.Products;

namespace Rookie.CustomerSite.Pages
{
    public class DetailModel : PageModel
    {
        private readonly IProductService _productService;

        public DetailModel(IProductService productService)
        {
            _productService = productService;
        }

        public ProductViewModel Product { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ProductId { get; set; }

        public async Task OnGet()
        {
            Product = await _productService.GetById(ProductId);
        }
    }
}