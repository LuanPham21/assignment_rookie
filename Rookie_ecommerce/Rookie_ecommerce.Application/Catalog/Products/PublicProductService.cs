using Microsoft.EntityFrameworkCore;
using RookieShop.Data.EF;
using RookieShop.ViewModel.Catalog.Products;
using RookieShop.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie_ecommerce.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly EcommerceDbContext _context;

        public PublicProductService(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest reuqest)
        {
            //1 Select join
            var query = from p in _context.Products
                        join pic in _context.ProductsInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pic };
            //2 filter
            if (reuqest.CategoryId.HasValue && reuqest.CategoryId.Value > 0)
                query = query.Where(p => p.pic.CategoryId == reuqest.CategoryId);

            //3Paing
            int totalRow = await query.CountAsync();
            var data = await query.Skip((reuqest.PageIndex - 1) * reuqest.PageSize)
                .Take(reuqest.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.p.Name,
                    Quantity = x.p.Quantity,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    Description = x.p.Description,
                    TimeCreate = x.p.TimeCreate,
                    Status = x.p.Status,
                    ViewCount = 0,
                    Details = x.p.Details,
                }).ToListAsync();

            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data,
            };
            return pagedResult;
        }
    }
}