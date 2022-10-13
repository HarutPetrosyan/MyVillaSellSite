using MagicVilla_Web.Models.DTO;

namespace MagicVilla_Web.Services.IServices
{
    public interface IVillaService
    {
        Task<T> GatAllAsync<T>(string Token);
        Task<T> GetByIdAsync<T>(int Id, string Token);
        Task<T> CreateAsync<T>(VillaCreateDto dto, string Token);
        Task<T> UpdateAsync<T>(VillaUpdateDto dto, string Token);
        Task<T> DeleteAsync<T>(int Id, string Token);
    }
}
