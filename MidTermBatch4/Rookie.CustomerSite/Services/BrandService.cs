using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RookieShop.Shared;
using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.Brand;

public class BrandService : IBrandService
{
    private readonly IHttpClientFactory _clientFactory;

    public BrandService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<PagedResponseDto<BrandDto>> GetBrandAsync(BrandCriteriaDto brandCriteriaDto)
    {
        var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
        var getBrandsEndpoint = string.IsNullOrEmpty(brandCriteriaDto.Search) ? 
                                    EndpointConstants.GET_BRANDS :
                                    $"{EndpointConstants.GET_BRANDS}?Search={brandCriteriaDto.Search}";
        
        var response = await client.GetAsync(getBrandsEndpoint);
        response.EnsureSuccessStatusCode();
        var pagedBrands = await response.Content.ReadAsAsync<PagedResponseDto<BrandDto>>();
        return pagedBrands;
    }

    public async Task<BrandDto> GetBrandByIdAsync(int id)
    {
        var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
        var response = await client.GetAsync($"{EndpointConstants.GET_BRANDS}\\{id}");
        response.EnsureSuccessStatusCode();
        var Brand = await response.Content.ReadAsAsync<BrandDto>();
        return Brand;
    }

    public async Task<bool> UpdateBrand(BrandDto brand)
    {
        var brandCreateRequest = new BrandCreateRequest
        {
             Name = brand.Name
        };

        //var json = JsonConvert.SerializeObject(brandCreateRequest);
        //var data = new StringContent(json, Encoding.UTF8, "application/json");
        var content = new MultipartFormDataContent();
        content.Add(new StringContent(brand.Name), "Name");

        var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
        var res = await client.PutAsync(
                            $"{EndpointConstants.GET_BRANDS}\\{brand.Id}",
                            content);

        res.EnsureSuccessStatusCode();

        return await Task.FromResult(true);
    }
}