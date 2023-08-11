using System.Data.SqlClient;

namespace OpenERX.Repositories.Shared.Sql
{
    public interface IConnectionProvider
    {
        SqlConnection CreateConnection();
        Task<SqlConnection> CreateConnectionAsync();
    }
}