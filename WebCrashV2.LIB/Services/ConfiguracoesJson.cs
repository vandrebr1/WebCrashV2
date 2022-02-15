using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrashV2.LIB.Services
{
    public class ConfiguracoesJson
    {
        IConfigurationBuilder builder;
        IConfigurationRoot config;

        public ConfiguracoesJson()
        {
            builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            config = builder.Build();
        }

        public string GetConnectionString()
        {
            return config["DatabaseOptions:ConnectionString"];
        }

        public string GetProviderName()
        {
            return config["DatabaseOptions:ProviderName"];
        }

        public string GetUserDataDir()
        {
            return config["ChromeOptions:UserDataDir"];
        }

        public string GetProfileDirectory()
        {
            return config["ChromeOptions:ProfileDirectory"];
        }
    }
}
