using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Core.Connections.SQLServer
{
    public interface ISQLServerConnection
    {
        public IDbConnection GetIDbConnection(string? catalog);
        public IDbConnection GetIDbConnection();
        public SqlConnection GetDbConnection(string? catalog);
        public SqlConnection GetDbConnection();
    }
}
