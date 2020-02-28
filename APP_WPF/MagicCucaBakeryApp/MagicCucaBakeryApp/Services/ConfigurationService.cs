using MagicCucaBakeryApp.Models.Configuration;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.IO;
using System.Text.Json;

namespace MagicCucaBakeryApp.Services
{
    internal class ConfigurationService
    {
        private const string configFileName = "appsettings.json";
        private static ConfigurationService instance;
        private IConfiguration configurationFile;

        private ConfigurationService()
        {
            configurationFile = new ConfigurationBuilder()
                .AddJsonFile(configFileName, false)
                .Build();
            Configuration = new LocalConfiguration();
            configurationFile.Bind(Configuration);
            Configuration.PropertyChanged += Configuration_PropertyChanged;
        }

        public static ConfigurationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConfigurationService();
                }
                return instance;
            }
        }

        public LocalConfiguration Configuration { get; set; }

        private void Configuration_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SaveConfig();
        }

        private void SaveConfig()
        {
            using (StreamWriter file = new StreamWriter(configFileName))
            {
                file.Write(JsonSerializer.Serialize(Configuration));
            }
        }
    }
}