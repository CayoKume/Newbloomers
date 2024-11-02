using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace IntegrationsCore.Infrastructure.Connections.MySQL
{
    public class LinxCommerceConnection : ILinxCommerceConnection, IDisposable
    {
        private readonly string? _connectionstring;
        private IConfiguration? _configuration;
        private IDbConnection _connection;
        private SqlConnection _conn;

        public LinxCommerceConnection(IDbConnection connection, IConfiguration configuration) =>
            (_connection, _configuration) = (connection, configuration);

        public LinxCommerceConnection(IConfiguration configuration) =>
            _connectionstring = configuration.GetConnectionString("Connection");

        public void Dispose() => _connection?.Dispose();

        public SqlConnection GetDbConnection()
        {
            try
            {
                string? databaseName = _configuration.GetSection("ConfigureServer").GetSection("LinxCommerceDatabaseName").Value;
                _conn = new SqlConnection(_connectionstring.Replace("[catalog]", databaseName).Replace("[database]", databaseName));
                _conn.Open();
                return _conn;
            }
            catch (Exception ex)
            {
                _connection?.Dispose();
                throw new InvalidOperationException("Failed to establish a database connection.", ex);
            }
        }

        public IDbConnection GetIDbConnection()
        {
            try
            {
                string? databaseName = _configuration.GetSection("ConfigureServer").GetSection("GeneralDatabaseName").Value;
                _conn = new SqlConnection(_connectionstring.Replace("[catalog]", databaseName).Replace("[database]", databaseName));
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
