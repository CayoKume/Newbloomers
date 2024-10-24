using System.Data;

namespace IntegrationsCore.Infrastructure.Connections.MySQL
{
    public interface IMySQLConnection
    {
        public IDbConnection GetIDbConnection();
    }
}
