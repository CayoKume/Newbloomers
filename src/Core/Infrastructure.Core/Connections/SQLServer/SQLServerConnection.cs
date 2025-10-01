using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Core.Connections.SQLServer
{
    public class SQLServerConnection : ISQLServerConnection, IDisposable
    {
        private readonly IConfiguration _configuration;
        private readonly string? _connectionstring;
        private IDbConnection _connection;
        private SqlConnection _conn;

        public SQLServerConnection(IConfiguration configuration) =>
            (_configuration, _connectionstring) = (configuration, configuration.GetConnectionString("Connection"));

        public void Dispose() => _connection?.Dispose();

        public SqlConnection GetDbConnection(string? catalog)
        {
            try
            {
                _conn = new SqlConnection(_connectionstring.Replace("[catalog]", catalog).Replace("[database]", catalog));
                _conn.Open();
                return _conn;
            }
            catch (Exception ex)
            {
                _conn?.Dispose();
                throw new InvalidOperationException("Failed to establish a database connection.", ex);
            }
        }

        public IDbConnection GetIDbConnection(string? catalog)
        {
            try
            {
                _connection = new SqlConnection(_connectionstring.Replace("[catalog]", catalog).Replace("[database]", catalog));
                _connection.Open();
                return _connection;
            }
            catch (Exception ex)
            {
                _connection?.Dispose();
                throw new InvalidOperationException("Failed to establish a database connection.", ex);
            }
        }

        public SqlConnection GetDbConnection()
        {
            try
            {
                _conn = new SqlConnection(_connectionstring.Replace("[catalog]", "NEWBLOOMERS").Replace("[database]", "NEWBLOOMERS"));
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
                _connection = new SqlConnection(_connectionstring.Replace("[catalog]", "NEWBLOOMERS").Replace("[database]", "NEWBLOOMERS"));
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
