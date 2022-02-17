using AutoMapper;
using RookieShop.Backend.Helpers;
using RookieShop.Backend.Models;
using RookieShop.BackEnd.Services;
using RookieShop.Shared.Dto.Brand;

namespace RookieShop.Backend.Data.Mapping
{
    public class AutoMapperProfile : Profile  
    {
        public AutoMapperProfile()  
        {  
            CreateMap<Brand, BrandDto>()
                .ForMember(src => src.ImagePath,
                           opts => opts
                                    .MapFrom(src => ImageHelper
                                                        .GetFileUrl(src.ImageName)
                                            ));  
        }  
    }
}