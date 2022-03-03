using RookieShop.Data.EF;
using RookieShop.Data.Entities;
using RookieShop.Utilities.Exeptions;
using RookieShop.ViewModel.Catalog.Products;
using RookieShop.ViewModel.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Rookie_ecommerce.Application.Common;

namespace Rookie_ecommerce.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly EcommerceDbContext _context;
        private readonly IStorageService _storageService;

        public ManageProductService(EcommerceDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public Task<int> AddImages(int productId, List<IFormFile> files)
        {
            throw new NotImplementedException();
        }

        public async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Name = request.Name,
                Quantity = request.Quantity,
                OriginalPrice = request.OriginalPrice,
                Price = request.Price,
                Description = request.Description,
                TimeCreate = DateTime.Now,
                Status = request.Status,
                ViewCount = 0,
                Details = request.Details,
            };
            if (request.ThumnailImage != null)
            {
                product.Images = new List<Image>()
                {
                    new Image()
                    {
                        Caption = "Thumnail Image",
                        DateCreate = DateTime.Now,
                        ImageLink = await this.SaveFile(request.ThumnailImage),
                        SortOrder = 1
                    }
                };
            }
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new RookieShopException($"Cannot find a product {productId}");
            }
            var images = _context.Images.Where(x => x.ProductId == productId);
            foreach (var item in images)
            {
                await _storageService.DeleteFileAsync(item.ImageLink);
            }
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest reuqest)
        {
            // Select Join
            var query = from p in _context.Products
                        join pic in _context.ProductsInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pic };
            if (!string.IsNullOrEmpty(reuqest.Keyword))
                query = query.Where(x => x.p.Name.Contains(reuqest.Keyword));
            if (reuqest.CategoryIds.Count() > 0)
                query = query.Where(p => reuqest.CategoryIds.Contains(p.pic.CategoryId));

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

        public Task<List<ProductImageViewModel>> GetListImage(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveImages(int imageId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            if (product == null)
                throw new RookieShopException($"Cannot find a product with id: {request.Id}");
            product.TimeCreate = DateTime.Now;
            product.Name = request.Name;
            product.Description = request.Description;
            product.Details = request.Details;
            if (request.ThumnailImage != null)
            {
                var thumnail = await _context.Images.FirstOrDefaultAsync(x => x.ProductId == request.Id);
                if (thumnail != null)
                {
                    thumnail.ImageLink = await this.SaveFile(request.ThumnailImage);
                    _context.Images.Update(thumnail);
                }
            }
            return await _context.SaveChangesAsync();
        }

        public Task<int> UpdateImages(int imageId, string caption)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                throw new RookieShopException($"Cannot find a product with id: {productId}");
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                throw new RookieShopException($"Cannot find a product with id: {productId}");
            product.Quantity = addedQuantity;
            return await _context.SaveChangesAsync() > 0;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}