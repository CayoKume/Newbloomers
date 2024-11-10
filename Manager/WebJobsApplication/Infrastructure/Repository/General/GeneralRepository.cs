using IMySQLGeneralConnection = IntegrationsCore.Infrastructure.Connections.MySQL.IGeneral;
using ISQLGeneralConnection = IntegrationsCore.Infrastructure.Connections.SQLServer.IGeneral;
using IPostgreGeneralConnection = IntegrationsCore.Infrastructure.Connections.PostgreSQL.IGeneral;
using static Dapper.SqlMapper;
using static IntegrationsCore.Domain.Exceptions.RepositorysExceptions;
using Z.Dapper.Plus;

namespace WebJobsApplication.Infrastructure.Repository.General
{
    public class GeneralRepository<TEntity> : IGeneralRepository<TEntity> where TEntity : class, new()
    {
        private readonly ISQLGeneralConnection _sqlServerConnection;
        private readonly IPostgreGeneralConnection _postgreSQLConnection;
        private readonly IMySQLGeneralConnection _mySQLConnection;

        public GeneralRepository(ISQLGeneralConnection sqlServerConnection) =>
            _sqlServerConnection = sqlServerConnection;

        public GeneralRepository(IPostgreGeneralConnection postgreSQLConnection) =>
            _postgreSQLConnection = postgreSQLConnection;

        public GeneralRepository(IMySQLGeneralConnection mySQLConnection) =>
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
