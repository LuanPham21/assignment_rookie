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
        //private readonly IRatingService _ratingService;

        public ProductModel(ICategorySevice categorySevice,
            IProductService productService)
        {
            _categorySevice = categorySevice;
            _productService = productService;
        }

        public List<CategoryVm> Category;

        public List<ProductViewModel> Product { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CategoryId { get; set; }

        public string Keyword { get; set; }

        public async Task OnGet(string keyword, string category)
        {
            Product = await _productService.GetByName(keyword);

            Category = await _categorySevice.GetAll();
            CategoryId = category;
            if (!string.IsNullOrEmpty(category))
            {
                Product = await _productService.GetProductinCategory(int.Parse(category));
            }
            Keyword = keyword;
        }
    }
}