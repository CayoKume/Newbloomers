using System.Data;

namespace Infrastructure.Core.Connections.MySQL
{
    public interface IMySQLConnection
    {
        public IDbConnection GetIDbConnection();
    }
}
