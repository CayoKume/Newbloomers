using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace IntegrationsCore.Infrastructure.Connections.SQLServer
{
    public class SQLServerConnection : ISQLServerConnection, IDisposable
    {
        private readonly string? _connectionString;
        private IDbConnection _connection;
        private SqlConnection _conn;

        public SQLServerConnection(IConfiguration configuration) =>
            _connectionString = configuration.GetConnectionString("Connection");

        public void Dispose() => _connection?.Dispose();

        public SqlConnection GetDbConnection()
        {
            try
            {
                _conn = new SqlConnection(_connectionString.Replace("[catalog]", "master").Replace("[database]", "master"));
                _conn.Open();
                return _conn;
            }
            catch (Exception ex)
            {
                _conn?.Dispose();
                throw new InvalidOperationException("Failed to establish a database connection.", ex);
            }
        }

        public IDbConnection GetIDbConnection()
        {
            try
            {
                _connection = new SqlConnection(_connectionString.Replace("[catalog]", "master").Replace("[database]", "master"));
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
