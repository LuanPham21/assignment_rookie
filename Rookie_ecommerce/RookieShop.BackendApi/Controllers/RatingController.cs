using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookie_ecommerce.Application.Catalog.Products;
using RookieShop.Data.EF;
using RookieShop.ViewModel.Catalog.Products;

namespace RookieShop.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet]
        public async Task<IActionResult> InsertRating([FromQuery] RatingVM request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _ratingService.InsertRating(request);
            return Ok();
        }
    }
}