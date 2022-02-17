using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rookie.CustomerSite.Models;
using RookieShop.Shared.Dto.Brand;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBrandService _brandService;

        public HomeController(
            ILogger<HomeController> logger,
            IBrandService brandService
            )
        {
            _logger = logger;
            _brandService = brandService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
