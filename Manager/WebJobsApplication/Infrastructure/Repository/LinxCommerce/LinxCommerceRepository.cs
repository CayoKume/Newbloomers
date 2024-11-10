using IMySQLLinxCommerceConnection = IntegrationsCore.Infrastructure.Connections.MySQL.ILinxCommerce;
using ISQLLinxCommerceConnection = IntegrationsCore.Infrastructure.Connections.SQLServer.ILinxCommerce;
using IPostgreLinxCommerceConnection = IntegrationsCore.Infrastructure.Connections.PostgreSQL.ILinxCommerce;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using static IntegrationsCore.Domain.Exceptions.RepositorysExceptions;
using Z.Dapper.Plus;

namespace WebJobsApplication.Infrastructure.Connections.LinxCommerce
{
    public class LinxCommerceRepository<TEntity> : ILinxCommerceRepository<TEntity> where TEntity : class, new()
    {
        private readonly ISQLLinxCommerceConnection _sqlServerConnection;
        private readonly IPostgreLinxCommerceConnection _postgreSQLConnection;
        private readonly IMySQLLinxCommerceConnection _mySQLConnection;

        public LinxCommerceRepository(ISQLLinxCommerceConnection sqlServerConnection) =>
            _sqlServerConnection = sqlServerConnection;

        public LinxCommerceRepository(IPostgreLinxCommerceConnection postgreSQLConnection) =>
            _postgreSQLConnection = postgreSQLConnection;

        public LinxCommerceRepository(IMySQLLinxCommerceConnection mySQLConnection) =>
            _mySQLConnection = mySQLConnection;

        public async Task<bool> CreateDatabaseIfNotExists(string? projectName, string? databaseName)
        {
            string? sql = @$"IF NOT EXISTS (SELECT * FROM [MASTER].[dbo].[SYSDATABASES] WHERE NAME = '{databaseName}')
                            BEGIN
                              CREATE DATABASE {databaseName}
                            END";

            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection())
                {
                    var result = await conn.ExecuteAsync(sql: sql);

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ExecuteCommandException()
                {
                    project = $"{projectName}",
                    method = "CreateDatabaseIfNotExists",
                    schema = $"[MASTER].[dbo].[{databaseName}]",
                    job = " - ",
                    message = $"Error creating database: {databaseName}",
                    command = sql,
                    exception = ex.Message
                };
            }
        }

        public async Task<bool> CreateParametersDataTableIfNotExists(string? projectName, string? databaseName, string? tableName)
        {
            string? sql = @$"SELECT DISTINCT * FROM [{databaseName}].[INFORMATION_SCHEMA].[TABLES] (NOLOCK) WHERE TABLE_NAME LIKE '%{tableName}%'";

            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection())
                {
                    var result = await conn.QueryAsync(sql: sql);

                    if (result.Count() == 0)
                    {
                        conn.ChangeDatabase(databaseName);
                        conn.CreateTable<TEntity>(tableName: $"{tableName}");

                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ExecuteCommandException()
                {
                    project = $"{projectName}",
                    method = "CreateParametersDataTableIfNotExists",
                    schema = $"[{databaseName}].[dbo].[{tableName}]",
                    job = " - ",
                    message = $"Error creating datatable: {tableName}",
                    command = sql,
                    exception = ex.Message
                };
            }
        }
    }
}
