using System.Data;

namespace WebCrashV2.LIB.Repository.DB
{
    public class DbContext
    {
        private IDBProvider _dbProvider;

        public DbContext SetDbProvider(string providerType)
        {
            _dbProvider = _dbProvider = new SQLServerProvider();

            return this;
        }

        public IDbConnection GetDbContext(string connectionString)
            => _dbProvider.GetDbConnection(connectionString);
    }
}
