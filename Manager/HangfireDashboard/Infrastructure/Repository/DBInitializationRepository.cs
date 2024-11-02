using Dapper;
using static Dapper.SqlMapper;
using Z.Dapper.Plus;
using static IntegrationsCore.Domain.Entities.Exceptions.RepositorysExceptions;
using IntegrationsCore.Infrastructure.Connections.SQLServer;
using IntegrationsCore.Infrastructure.Connections.PostgreSQL;
using IntegrationsCore.Infrastructure.Connections.MySQL;

namespace HangfireDashboard.Infrastructure.Repository
{
    public class DBInitializationRepository<TEntity> : IDBInitializationRepository<TEntity> where TEntity : class, new()
    {
        private readonly ISQLServerConnection _sqlServerConnection;
        private readonly IPostgreSQLConnection _postgreSQLConnection;
        private readonly IMySQLConnection _mySQLConnection;

        public DBInitializationRepository(ISQLServerConnection sqlServerConnection) =>
            _sqlServerConnection = sqlServerConnection;

        public DBInitializationRepository(IPostgreSQLConnection postgreSQLConnection) =>
            _postgreSQLConnection = postgreSQLConnection;

        public DBInitializationRepository(IMySQLConnection mySQLConnection) =>
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
