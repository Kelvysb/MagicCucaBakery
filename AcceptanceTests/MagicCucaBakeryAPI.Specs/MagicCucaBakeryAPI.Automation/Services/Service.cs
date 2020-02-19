using MagicCucaBakeryAPI.Automation.Helpers;
using MagicCucaBakeryAPI.Automation.Models;
using MagicCucaBakeryAPI.Automation.Settings;
using Microsoft.Extensions.Configuration;
using System;
using System.Text.Json;

namespace MagicCucaBakeryAPI.Automation.Services
{
    public class Service
    {
        private readonly RequestHelper requestHelper;
        private readonly Action<string> setToken;
        private readonly Action<ApiResult> setLastResult;

        internal Service(Action<string> setToken, Action<ApiResult> setLastResult)
        {
            IConfiguration Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            Config config = new Config();
            Configuration.Bind(config);
            requestHelper = new RequestHelper(config);
            this.setToken = setToken;
            this.setLastResult = setLastResult;
        }

        public ApiResult Login(string userName, string password)
        {
            string passwordHash = HashHelper.GetMd5Hash(password);
            ApiResult result = requestHelper.Login(userName, passwordHash);
            setLastResult(result);
            if(result.ResultCode.Equals("OK", StringComparison.InvariantCultureIgnoreCase))
            {
                setToken(JsonDocument.Parse(result.Result).RootElement.GetProperty("token").GetString());
            }
            return result;
        }

        public ApiResult GetUsers(string token)
        {
            ApiResult result = requestHelper.GetUsers(token);
            setLastResult(result);
            return result;
        }
    }
}
