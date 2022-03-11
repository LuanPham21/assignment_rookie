using RookieShop.Data.EF;
using RookieShop.ViewModel.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie_ecommerce.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly EcommerceDbContext _context;

        public CategoryService(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryVm>> GetAll()
        {
            var query = from c in _context.Categories
                        select new { c };
            List<CategoryVm> listvm = new List<CategoryVm>();
            foreach (var cate in query)
            {
                var categgoryViewModel = new CategoryVm()
                {
                    Id = cate.c.Id,
                    Name = cate.c.Name,
                    ParentId = cate.c.ParentId
                };

                listvm.Add(categgoryViewModel);
            }
            return listvm;
        }

        public async Task<CategoryVm> GetById(int id)
        {
            var cate = await _context.Categories.FindAsync(id);
            var categgoryViewModel = new CategoryVm()
            {
                Id = cate.Id,
                Name = cate.Name,
                ParentId = cate.ParentId
            };
            return categgoryViewModel;
        }
    }
}