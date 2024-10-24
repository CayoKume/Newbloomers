using System.Data;
using System.Data.SqlClient;

namespace IntegrationsCore.Infrastructure.Connections.SQLServer
{
    public interface ISQLServerConnection
    {
        public IDbConnection GetIDbConnection();
        public SqlConnection GetDbConnection();
    }
}
