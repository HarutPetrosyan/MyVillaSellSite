using MagicVilla_Web.Models.DTO;

namespace MagicVilla_Web.Services.IServices
{
    public interface IVillaNumberService
    {
        Task<T> GatAllAsync<T>(string Token);
        Task<T> GetByIdAsync<T>(int Id, string Token);
        Task<T> CreateAsync<T>(VillaNumberCreatedDto dto, string Token);
        Task<T> UpdateAsync<T>(VillaNumberUpdatedDto dto, string Token);
        Task<T> DeleteAsync<T>(int Id, string Token);
    }
}
