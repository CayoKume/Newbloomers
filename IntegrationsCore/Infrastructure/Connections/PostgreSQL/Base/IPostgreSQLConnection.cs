
using System.Data;

namespace IntegrationsCore.Infrastructure.Connections.PostgreSQL
{
    public interface IPostgreSQLConnection
    {
        public IDbConnection GetIDbConnection();
    }
}
