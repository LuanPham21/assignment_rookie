using RookieShop.Data.EF;
using RookieShop.Data.Entities;
using RookieShop.Utilities.Exeptions;
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

        public async Task<int> Create(CategoriesCreateRequest request)
        {
            var cate = new Category()
            {
                Name = request.Name,
                ParentId = request.ParentId,
                Status = request.Status,
            };
            _context.Categories.Add(cate);
            await _context.SaveChangesAsync();
            return cate.Id;
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
                    ParentId = cate.c.ParentId,
                    Status = cate.c.Status
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
                ParentId = cate.ParentId,
                Status = cate.Status
            };
            return categgoryViewModel;
        }

        public async Task<int> Update(CategoriesUpdateRequest request)
        {
            var cate = await _context.Categories.FindAsync(request.Id);
            if (cate == null)
                throw new RookieShopException($"Cannot find a cate with id: {request.Id}");
            cate.Name = request.Name;
            cate.ParentId = request.ParentId;
            cate.Status = request.Status;
            return await _context.SaveChangesAsync();
        }
    }
}