using System.Data;

namespace WebCrashV2.LIB.Repository.DB
{
    interface IDBProvider
    {
        IDbConnection GetDbConnection(string connectionString);
    }
}
