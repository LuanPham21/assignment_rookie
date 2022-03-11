using RookieShop.ViewModel.Catalog.Categories;

namespace Rookie.CustomerSite.Service
{
    public interface ICategorySevice
    {
        public Task<List<CategoryVm>> GetAll();

        public Task<CategoryVm> GetById(int id);
    }
}