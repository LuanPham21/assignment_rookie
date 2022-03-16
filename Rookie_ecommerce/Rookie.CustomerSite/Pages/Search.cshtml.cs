using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rookie.CustomerSite.Service;
using RookieShop.ViewModel.Catalog.Products;

namespace Rookie.CustomerSite.Pages
{
    public class SearchModel : PageModel
    {
        private readonly IProductService _productService;

        public SearchModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<ProductViewModel> Product;
        public int Category { get; set; }

        public async Task OnGet(string productName, string categoryId)
        {
            if (!string.IsNullOrEmpty(productName))
            {
                /*                Product = await _productService.GetById();
                */
            }
        }
    }
}