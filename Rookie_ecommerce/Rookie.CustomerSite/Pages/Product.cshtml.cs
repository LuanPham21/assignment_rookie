using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rookie.CustomerSite.Service;
using RookieShop.ViewModel.Catalog.Categories;
using RookieShop.ViewModel.Catalog.Products;

namespace Rookie.CustomerSite.Pages
{
    public class ProductModel : PageModel
    {
        private readonly ICategorySevice _categorySevice;
        private readonly IProductService _productService;

        public ProductModel(ICategorySevice categorySevice,
            IProductService productService)
        {
            _categorySevice = categorySevice;
            _productService = productService;
        }

        public List<CategoryVm> Category;

        [BindProperty(SupportsGet = true)]
        public int CategoryId { get; set; }

        public async Task OnGet()
        {
            Category = await _categorySevice.GetAll();
        }
    }
}