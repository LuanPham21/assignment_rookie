using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookie_ecommerce.Application.Catalog.Products;
using RookieShop.ViewModel.Catalog.Products;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Infrastructure;

namespace RookieShop.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private readonly IPublicProductService _publicProductService;
        //private readonly IManageProductService _manageProductService;

        //public ProductController(IPublicProductService publicProductService,
        //    IManageProductService manageProductService)
        //{
        //    _publicProductService = publicProductService;
        //    _manageProductService = manageProductService;
        //}

        ////http://localhost:port/products?PageIndex=1&pagéize=10&CategoryId =
        //[HttpGet("public-paging")]
        //public async Task<IActionResult> GetAllPaging([FromQuery] GetPublicProductPagingRequest request)
        //{
        //    var products = await _publicProductService.GetAllByCategoryId(request);
        //    return Ok(products);
        //}

        ////http://localhost:port/product/1
        //[HttpGet("{productId}")]
        //public async Task<IActionResult> GetById(int productId)
        //{
        //    var products = await _manageProductService.GetById(productId);
        //    if (products == null)
        //        return BadRequest("Cannot find product");
        //    return Ok(products);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var productId = await _manageProductService.Create(request);
        //    if (productId == 0)
        //        return BadRequest();
        //    var product = await _manageProductService.GetById(productId);
        //    return CreatedAtAction(nameof(GetById), new { id = productId }, product);
        //}

        //[HttpPut]
        //public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var affectedResult = await _manageProductService.Update(request);
        //    if (affectedResult == 0)
        //        return BadRequest();
        //    return Ok();
        //}

        //[HttpDelete("{productId}")]
        //public async Task<IActionResult> Delete(int productId)
        //{
        //    var affectedResult = await _manageProductService.Delete(productId);
        //    if (affectedResult == 0)
        //        return BadRequest();
        //    return Ok();
        //}

        //[HttpPatch("{productId}/{newPrice}")]
        //public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice)
        //{
        //    var isSuccessful = await _manageProductService.UpdatePrice(productId, newPrice);
        //    if (isSuccessful)
        //        return Ok();
        //    return BadRequest();
        //}
    }
}