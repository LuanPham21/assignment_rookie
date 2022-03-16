using Microsoft.AspNetCore.Mvc;
using RookieShop.ViewModel.Catalog.Products;

namespace Rookie.CustomerSite.Service
{
    public interface IProductService
    {
        public Task<List<ProductViewModel>> GetListAsync();

        public Task<ProductViewModel> GetById(int productId);

        public Task<List<ProductViewModel>> GetProductinCategory(int CategoryId);

        public Task<List<ProductViewModel>> GetByName(string? name);
    }
}