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
            try
            {
                DBOption dbOptions = new DBOption();
                var dbContext = new DbContext().SetDbProvider(dbOptions.ProviderName);
                Connection = dbContext.GetDbContext(dbOptions.ConnectionString);
                Connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose() => Connection?.Dispose();
    }
}
