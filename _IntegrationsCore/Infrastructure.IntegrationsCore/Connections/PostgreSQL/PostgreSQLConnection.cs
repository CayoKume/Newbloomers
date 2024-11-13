using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.IntegrationsCore.Connections.PostgreSQL
{
    public class PostgreSQLConnection : IPostgreSQLConnection, IDisposable
    {
        private readonly string? _connectionstring;
        private IDbConnection _connection;

        public PostgreSQLConnection(IDbConnection connection) =>
            _connection = connection;

        public PostgreSQLConnection(IConfiguration configuration) =>
            _connectionstring = configuration.GetConnectionString("Connection");

        public void Dispose() => _connection?.Dispose();

        public IDbConnection GetIDbConnection()
        {
            try
            {
                _connection = new SqlConnection(_connectionstring.Replace("[catalog]", "master").Replace("[database]", "master"));
                _connection.Open();
                return _connection;
            }
            catch (Exception ex)
            {
                _connection?.Dispose();
                throw new InvalidOperationException("Failed to establish a database connection.", ex);
            }
        }
    }
}
