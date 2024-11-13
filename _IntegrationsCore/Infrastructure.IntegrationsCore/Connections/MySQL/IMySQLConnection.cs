using System.Data;

namespace Infrastructure.IntegrationsCore.Connections.MySQL
{
    public interface IMySQLConnection
    {
        public IDbConnection GetIDbConnection();
    }
}
