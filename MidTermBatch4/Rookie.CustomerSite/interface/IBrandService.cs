using System.Threading;
using System.Threading.Tasks;
using RookieShop.Shared;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.Brand;

public interface IBrandService
{
    Task<PagedResponseDto<BrandDto>> GetBrandAsync(BrandCriteriaDto brandCriteriaDto);
    Task<BrandDto> GetBrandByIdAsync(int id);
    Task<bool> UpdateBrand(BrandDto brand);
}