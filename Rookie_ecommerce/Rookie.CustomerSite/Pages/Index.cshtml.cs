using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rookie.CustomerSite.Service;
using RookieShop.ViewModel.Catalog.Products;

namespace Rookie.CustomerSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<ProductViewModel> Product;
        public string Ten { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Keyword { get; set; }

        public async Task OnGet()
        {
            Product = await _productService.GetListAsync();
        }
    }
}