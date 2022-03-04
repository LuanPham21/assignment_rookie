using RookieShop.Data.EF;
using RookieShop.Data.Entities;
using RookieShop.Utilities.Exeptions;
using RookieShop.ViewModel.Catalog.Products;
using RookieShop.ViewModel.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Rookie_ecommerce.Application.Common;
using RookieShop.ViewModel.Catalog.ProductImages;

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

        public async Task<int> AddImages(int productId, ProductImageCreateRequest request)
        {
            var productImage = new Image()
            {
                Caption = request.Caption,
                DateCreate = DateTime.Now,
                ProductId = productId,
                SortOrder = request.SortOrder,
            };
            if (request.ImageFile != null)
            {
                productImage.ImageLink = await this.SaveFile(request.ImageFile);
            }
            _context.Images.Add(productImage);
            await _context.SaveChangesAsync();
            return productImage.Id;
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
            await _context.SaveChangesAsync();
            return product.Id;
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

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request)
        {
            // Select Join
            var query = from p in _context.Products
                        join pic in _context.ProductsInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pic };
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.Name.Contains(request.Keyword));
            if (request.CategoryIds.Count() > 0)
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));

            //3Paing
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
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

        public async Task<ProductViewModel> GetById(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            var productViewModel = new ProductViewModel()
            {
                Id = product.Id,
                TimeCreate = product.TimeCreate,
                Name = product.Name,
                Quantity = product.Quantity,
                OriginalPrice = product.OriginalPrice,
                Price = product.Price,
                Description = product.Description,
                Status = product.Status,
                ViewCount = product.ViewCount,
                Details = product.Details,
            };
            return productViewModel;
        }

        public async Task<ProductImageViewModel> GetImageById(int imageId)
        {
            var image = await _context.Images.FindAsync(imageId);
            if (image == null)
                throw new RookieShopException($"Cannot find an image with id{imageId}");
            var ViewModel = new ProductImageViewModel()
            {
                Id = image.Id,
                ImageLink = image.ImageLink,
                ProductId = image.ProductId,
                DateCreate = image.DateCreate,
                SortOrder = image.SortOrder,
                Caption = image.Caption,
            };
            return ViewModel;
        }

        public async Task<List<ProductImageViewModel>> GetListImages(int productId)
        {
            return await _context.Images.Where(x => x.ProductId == productId)
                .Select(i => new ProductImageViewModel()
                {
                    Id = i.Id,
                    ImageLink = i.ImageLink,
                    ProductId = i.ProductId,
                    DateCreate = i.DateCreate,
                    SortOrder = i.SortOrder,
                    Caption = i.Caption,
                }).ToListAsync();
        }

        public async Task<int> RemoveImages(int imageId)
        {
            var productImage = await _context.Images.FindAsync(imageId);
            if (productImage == null)
                throw new RookieShopException($"Cannot find an image with id {imageId}");
            _context.Images.Remove(productImage);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            if (product == null)
                throw new RookieShopException($"Cannot find a product with id: {request.Id}");
            product.Name = request.Name;
            product.Description = request.Description;
            product.Details = request.Details;
            product.OriginalPrice = request.OriginalPrice;
            product.Status = request.Status;
            product.ViewCount = request.ViewCount;

            if (request.ThumnailImage != null)
            {
                var thumnail = await _context.Images.FirstOrDefaultAsync(i => i.ProductId == request.Id);
                if (thumnail != null)
                {
                    thumnail.ImageLink = await this.SaveFile(request.ThumnailImage);
                    _context.Images.Update(thumnail);
                }
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateImages(int imageId, ProductImageUpdateRequest request)
        {
            var productImage = await _context.Images.FindAsync(imageId);
            if (productImage == null)
                throw new RookieShopException($"Cannot find an image with id{imageId}");

            if (request.ImageFile != null)
            {
                productImage.ImageLink = await this.SaveFile(request.ImageFile);
            }
            _context.Images.Update(productImage);
            return await _context.SaveChangesAsync();
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