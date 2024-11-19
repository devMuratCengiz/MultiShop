using MultiShop.Dto.CatalogDtos.ServiceDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ServiceServices
{
    public interface IServiceService
    {
        Task<List<ResultServiceDto>> GetAllServicesAsync();
        Task CreateServiceAsync(CreateServiceDto createServiceDto);
        Task UpdateServiceAsync(UpdateServiceDto updateServiceDto);
        Task DeleteServiceAsync(string id);
        Task<UpdateServiceDto> GetByIdServiceAsync(string id);
    }
}
