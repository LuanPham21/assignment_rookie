using RookieShop.ViewModel.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie_ecommerce.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryVm>> GetAll();

        Task<CategoryVm> GetById(int id);

        Task<int> Create(CategoriesCreateRequest request);

        Task<int> Update(CategoriesUpdateRequest request);
    }
}