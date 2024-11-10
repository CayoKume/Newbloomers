
using System.Data;

namespace Infrastructure.IntegrationsCore.Connections.PostgreSQL
{
    public interface IPostgreSQLConnection
    {
        public IDbConnection GetIDbConnection();
    }
}
