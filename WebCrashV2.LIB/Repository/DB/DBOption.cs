using Microsoft.Extensions.Configuration;
using WebCrashV2.LIB.Services;

namespace WebCrashV2.LIB.Repository.DB
{
    public class DBOption
    {
        public DBOption()
        {
            var configuracoesJson = new ConfiguracoesJson();

            ConnectionString = configuracoesJson.GetConnectionString();
            ProviderName = configuracoesJson.GetProviderName();

        }

        public string ProviderName { get; set; }
        public string ConnectionString { get; set; }

    }

}
