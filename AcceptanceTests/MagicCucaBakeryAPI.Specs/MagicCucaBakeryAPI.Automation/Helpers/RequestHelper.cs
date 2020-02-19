using MagicCucaBakeryAPI.Automation.Models;
using MagicCucaBakeryAPI.Automation.Settings;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MagicCucaBakeryAPI.Automation.Helpers
{
    class RequestHelper
    {
        private readonly Config config;

        public RequestHelper(Config config)
        {
            this.config = config;
        }

        internal ApiResult Login(string userName, string passwordHash)
        {          
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(config.API.Endpoint);

                var content = new
                {
                    Login = userName,
                    Password = passwordHash
                };
                
                StringContent stringContent = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json");

                Task<HttpResponseMessage> apiResult = client.PostAsync(config.API.Login, stringContent);

                return new ApiResult()
                {
                    ResultCode = apiResult.Result.StatusCode.ToString(),
                    Result = apiResult.Result.Content.ReadAsStringAsync().Result
                };
            }
        }

        internal ApiResult GetUsers(string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(config.API.Endpoint);

                client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

                Task<HttpResponseMessage> apiResult = client.GetAsync(config.API.GetUsers);

                return new ApiResult()
                {
                    ResultCode = apiResult.Result.StatusCode.ToString(),
                    Result = apiResult.Result.Content.ReadAsStringAsync().Result
                };
            }
        }
    }
}
