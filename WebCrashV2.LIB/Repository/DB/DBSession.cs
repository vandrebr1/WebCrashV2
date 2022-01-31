using System;
using System.Data;

namespace WebCrashV2.LIB.Repository.DB
{
    public sealed class DBSession : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DBSession()
        {
            DBOption dbOptions = new DBOption();
            var dbContext = new DbContext().SetDbProvider(dbOptions.ProviderName);
            Connection = dbContext.GetDbContext(dbOptions.ConnectionString);
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
