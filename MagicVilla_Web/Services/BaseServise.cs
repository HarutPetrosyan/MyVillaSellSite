using System.Net;
using System.Net.Http.Headers;
using System.Text;
using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Services.IServices;
using Newtonsoft.Json;

namespace MagicVilla_Web.Services
{
    public class BaseServise : IBaseService
    {
        public APIResponse responseModel { get; set; }
        public IHttpClientFactory _httpClient { get; set; }
        public BaseServise(IHttpClientFactory httpClient)
        {
            this.responseModel = new();
            _httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                var client = _httpClient.CreateClient("MagicAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8,
                        "application/json");
                }

                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                HttpResponseMessage apiResponseMessage = null;
                if (!string.IsNullOrEmpty(apiRequest.Token))
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", apiRequest.Token);
                }
                apiResponseMessage = await client.SendAsync(message);
                var apiContent = await apiResponseMessage.Content.ReadAsStringAsync();
                try
                {
                    APIResponse apiResponse = JsonConvert.DeserializeObject<APIResponse>(apiContent);
                    if (apiResponse!=null&&(apiResponseMessage.StatusCode == HttpStatusCode.BadRequest ||
                        apiResponseMessage.StatusCode == HttpStatusCode.NotFound))
                    {
                        apiResponse.StatusCode = HttpStatusCode.BadRequest;
                        apiResponse.IsSuccess = false;
                        var res = JsonConvert.SerializeObject(apiResponse);
                        var returnObj = JsonConvert.DeserializeObject<T>(res);
                        return returnObj;
                    }
                }
                catch (Exception e)
                {
                    var apiResponse = JsonConvert.DeserializeObject<T>(apiContent);
                    return apiResponse;
                }

                var APIResponse = JsonConvert.DeserializeObject<T>(apiContent);
                return APIResponse;


            }
            catch (Exception e)
            {
                var Dto = new APIResponse()
                {
                    ErrorMessages = new List<string> { Convert.ToString(e.Message) },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(Dto);
                var apiResponse = JsonConvert.DeserializeObject<T>(res);
                return apiResponse;
            }
        }
    }
}
