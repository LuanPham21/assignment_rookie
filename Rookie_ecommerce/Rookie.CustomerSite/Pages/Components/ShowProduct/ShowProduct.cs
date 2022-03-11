using Microsoft.AspNetCore.Mvc;
using RookieShop.ViewModel.Catalog.Products;

namespace Rookie.CustomerSite.Pages.Components.ShowProduct
{
    public class ShowProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<ProductViewModel> Product)
        {
            return View<List<ProductViewModel>>(Product);
        }
    }
}