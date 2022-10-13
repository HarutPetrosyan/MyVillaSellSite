using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
    public class AuthService : BaseServise, IAuthService
    {
        private readonly IHttpClientFactory _httpClient;
        private string _villaUrl;

        public AuthService(IHttpClientFactory httpClient, IConfiguration configuration) : base(httpClient)
        {
            _httpClient = httpClient;
            _villaUrl = configuration.GetValue<string>("ServiceUrls:VillaApi");
        }



        public Task<T> LoginAsync<T>(LoginRequestDTO loginRequestDTO)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = loginRequestDTO,
                Url = _villaUrl + "/api/v1/UsersAuth/login"
            });
        }

        public Task<T> RegisterAsync<T>(RegistrationRequestDTO user)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = user,
                Url = _villaUrl + "/api/v1/UsersAuth/registration"
            });
        }
    }
}
