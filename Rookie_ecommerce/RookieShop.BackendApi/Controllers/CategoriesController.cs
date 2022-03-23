using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookie_ecommerce.Application.Catalog.Categories;
using RookieShop.ViewModel.Catalog.Categories;

namespace RookieShop.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _categoryService.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoriesCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cateId = await _categoryService.Create(request);
            if (cateId == 0)
                return BadRequest();
            //var product = await _productService.GetById(productId);
            return CreatedAtAction(nameof(GetById), new { id = cateId });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] CategoriesUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _categoryService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = await _categoryService.GetById(id);
            return Ok(category);
        }
    }
}