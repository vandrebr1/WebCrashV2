using Microsoft.Extensions.Configuration;

namespace WebCrashV2.LIB.Repository.DB
{
    public class DBOption
    {
        public DBOption()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);

            var config = builder.Build(); 

            ConnectionString = config["DatabaseOptions:ConnectionString"];
            ProviderName = config["DatabaseOptions:ProviderName"];

        }

        public string ProviderName { get; set; }
        public string ConnectionString { get; set; }

    }

}
