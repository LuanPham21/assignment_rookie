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
    public class IndexModel : PageModel
    {
        private readonly IBrandService _brandService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public IndexModel(
            IBrandService brandService,
            IConfiguration config,
            IMapper mapper)
        {
            _brandService = brandService;
            _config = config;
            _mapper = mapper;
        }

        public PagedResponseVM<BrandVm> Brands { get; set; }
        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            var brandCriteriaDto = new BrandCriteriaDto() {
                Search = searchString,
                SortOrder = SortOrderEnum.Accsending,
                Page = pageIndex ?? 1,
                Limit = int.Parse(_config[ConfigurationConstants.PAGING_LIMIT])
            };
            var pagedBrands = await _brandService.GetBrandAsync(brandCriteriaDto);
            Brands = _mapper.Map<PagedResponseVM<BrandVm>>(pagedBrands);
        }
    }
}
