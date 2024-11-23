using IMySQLLinxMicrovixConnection = IntegrationsCore.Infrastructure.Connections.MySQL.ILinxMicrovixERP;
using ISQLLinxMicrovixConnection = IntegrationsCore.Infrastructure.Connections.SQLServer.ILinxMicrovixERP;
using IPostgreLinxMicrovixConnection = IntegrationsCore.Infrastructure.Connections.PostgreSQL.ILinxMicrovixERP;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using static Domain.IntegrationsCore.Exceptions.RepositorysExceptions;
using Z.Dapper.Plus;

namespace WebJobsApplication.Infrastructure.Connections.LinxMicrovix
{
    public class LinxMicrovixRepository<TEntity> : ILinxMicrovixRepository<TEntity> where TEntity : class, new()
    {
        private readonly ISQLLinxMicrovixConnection _sqlServerConnection;
        private readonly IPostgreLinxMicrovixConnection _postgreSQLConnection;
        private readonly IMySQLLinxMicrovixConnection _mySQLConnection;

        public LinxMicrovixRepository(ISQLLinxMicrovixConnection sqlServerConnection) =>
            _sqlServerConnection = sqlServerConnection;

        public LinxMicrovixRepository(IPostgreLinxMicrovixConnection postgreSQLConnection) =>
            _postgreSQLConnection = postgreSQLConnection;

        public LinxMicrovixRepository(IMySQLLinxMicrovixConnection mySQLConnection) =>
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
