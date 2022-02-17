using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Rookie.CustomerSite.ViewModel;
using Rookie.CustomerSite.ViewModel.Brand;
using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto.Brand;
using RookieShop.Shared.Enum;

namespace Rookie.CustomerSite.Pages.Brands
{
    public class EditModel : PageModel
    {
        private readonly IBrandService _brandService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public EditModel(
            IBrandService brandService,
            IConfiguration config,
            IMapper mapper)
        {
            _brandService = brandService;
            _config = config;
            _mapper = mapper;
        }

        [BindProperty]
        public BrandVm Brand { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brandDto = await _brandService.GetBrandByIdAsync(id.Value);

            if (brandDto == null)
            {
                return NotFound();
            }
            Brand = _mapper.Map<BrandVm>(brandDto);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid || id < 0)
            {
                return NotFound();
            }

            var brandDto =_mapper.Map<BrandDto>(Brand);
            if (await _brandService.UpdateBrand(brandDto))
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
