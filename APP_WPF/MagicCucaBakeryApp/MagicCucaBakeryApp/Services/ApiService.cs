using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MagicCucaBakeryApp.Services
{
    internal class ApiService
    {
        public async Task<string> Get(string endpoint)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationService.Instance.Configuration.ApiUri);
                if (!string.IsNullOrEmpty(ConfigurationService.Instance.Configuration.Token))
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", ConfigurationService.Instance.Configuration.Token);
                }
                return await client.GetStringAsync(endpoint);
            }
        }

        public async Task<string> Post(string endpoint, object body)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationService.Instance.Configuration.ApiUri);
                if (!string.IsNullOrEmpty(ConfigurationService.Instance.Configuration.Token))
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", ConfigurationService.Instance.Configuration.Token);
                }
                StringContent bodyContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "aplication/json");
                HttpResponseMessage response = await client.PostAsync(endpoint, bodyContent);
                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> Put(string endpoint, object body)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationService.Instance.Configuration.ApiUri);
                if (!string.IsNullOrEmpty(ConfigurationService.Instance.Configuration.Token))
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", ConfigurationService.Instance.Configuration.Token);
                }
                StringContent bodyContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "aplication/json");
                HttpResponseMessage response = await client.PostAsync(endpoint, bodyContent);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}