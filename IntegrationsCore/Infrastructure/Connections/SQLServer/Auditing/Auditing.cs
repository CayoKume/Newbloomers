using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace IntegrationsCore.Infrastructure.Connections.SQLServer.Auditing
{
    public class Auditing : IAuditing, IDisposable
    {
        private readonly string? _databaseName;
        private readonly string? _connectionstring;
        private IDbConnection _connection;
        private SqlConnection _conn;

        public Auditing(IConfiguration configuration)
        {
            _databaseName = configuration.GetSection("ConfigureServer").GetSection("AuditingDatabaseName").Value;
            _connectionstring = configuration.GetConnectionString("Connection");
        }

        public void Dispose() => _connection?.Dispose();

        public SqlConnection GetDbConnection()
        {
            try
            {
                _conn = new SqlConnection(_connectionstring.Replace("[catalog]", _databaseName).Replace("[database]", _databaseName));
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
                _connection = new SqlConnection(_connectionstring.Replace("[catalog]", _databaseName).Replace("[database]", _databaseName));
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
