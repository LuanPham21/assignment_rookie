using AutoMapper;
using Rookie.CustomerSite.ViewModel;
using Rookie.CustomerSite.ViewModel.Brand;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.Brand;

namespace Rookie.CustomerSite.Mapping
{
    public class BrandAutoMapperProfile : Profile
    {
        public BrandAutoMapperProfile()  
        {  
            CreateMap<BrandDto, BrandVm>().ReverseMap();
            CreateMap<BaseQueryCriteriaDto, BaseQueryCriteriaVM>().ReverseMap();  
            CreateMap<PagedResponseDto<BrandDto>, PagedResponseVM<BrandVm>>().ReverseMap();
        }  
    }
}
