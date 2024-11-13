using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.IntegrationsCore.Connections.SQLServer
{
    public interface ISQLServerConnection
    {
        public IDbConnection GetIDbConnection(string catalog);
        public SqlConnection GetDbConnection(string catalog);
    }
}
