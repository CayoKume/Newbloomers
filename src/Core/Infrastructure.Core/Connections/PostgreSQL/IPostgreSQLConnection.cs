
using System.Data;

namespace Infrastructure.Core.Connections.PostgreSQL
{
    public interface IPostgreSQLConnection
    {
        public IDbConnection GetIDbConnection();
    }
}
