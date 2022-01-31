using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace WebCrashV2.LIB.Repository.DB
{
    public class SQLServerProvider : IDBProvider
    {
        public SQLServerProvider()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.SQLServer);
        }

        public IDbConnection GetDbConnection(string connectionString) => new SqlConnection(connectionString);
    }
}
