using Microsoft.AspNetCore.Mvc;
using RookieShop.ViewModel.Catalog.Products;

namespace Rookie.CustomerSite.Pages.Components.Banner
{
    public class BannerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<ProductViewModel> Product)
        {
            return View<List<ProductViewModel>>(Product);
        }
    }
}