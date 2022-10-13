using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
    public class VillaService : BaseServise, IVillaService
    {
        private readonly IHttpClientFactory _httpClient;
        private string _villaUrl;
        public VillaService(IHttpClientFactory httpClient, IConfiguration configuration) : base(httpClient)
        {
            _httpClient = httpClient;
            _villaUrl = configuration.GetValue<string>("ServiceUrls:VillaApi");
        }
        public Task<T> GatAllAsync<T>(string Token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = _villaUrl + "/api/v1/VillaApi",
                Token = Token
            });
        }

        public Task<T> GetByIdAsync<T>(int Id, string Token)
        {
             return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = _villaUrl + "/api/v1/VillaApi/" + Id,
                Token = Token
             });
        }
        

        public Task<T> CreateAsync<T>(VillaCreateDto dto, string Token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = _villaUrl+ "/api/v1/VillaApi",
                Token = Token

            });
        }

        public Task<T> UpdateAsync<T>(VillaUpdateDto dto, string Token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = _villaUrl + "/api/v1/VillaApi/" + dto.Id,
                Token = Token
                
            });
        }

        public Task<T> DeleteAsync<T>(int Id, string Token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = _villaUrl + "/api/v1/VillaApi/" + Id,
                Token = Token
            });
        }


    }
}
