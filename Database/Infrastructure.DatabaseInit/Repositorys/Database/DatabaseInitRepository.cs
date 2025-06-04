using Dapper;
using Domain.DatabaseInit.Interfaces.Database;
using Infrastructure.IntegrationsCore.Connections.SQLServer;

namespace Infrastructure.DatabaseInit.Repositorys.Database
{
    public class DatabaseInitRepository : IDatabaseInitRepository
    {
        private readonly ISQLServerConnection _sqlServerConnection;

        public DatabaseInitRepository(ISQLServerConnection sqlServerConnection) =>
            _sqlServerConnection = sqlServerConnection;

        public async Task<bool> CreateDatabasesIfNotExists(List<string> databases)
        {
            foreach (var database in databases)
            {
                string? sql = @$"IF NOT EXISTS (SELECT * FROM [MASTER].[dbo].[SYSDATABASES] WHERE NAME = '{database}')
                            BEGIN
                              CREATE DATABASE {database}
                            END";

                try
                {
                    using (var conn = _sqlServerConnection.GetIDbConnection("master"))
                    {
                        var result = await conn.ExecuteAsync(sql: sql);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                    //throw new ExecuteCommandException()
                    //{
                    //    project = $"{projectName}",
                    //    method = "CreateDatabaseIfNotExists",
                    //    schema = $"[MASTER].[dbo].[{databaseName}]",
                    //    job = " - ",
                    //    message = $"Error creating database: {databaseName}",
                    //    command = sql,
                    //    exception = ex.Message
                    //};
                }
            }

            return true;
        }
    }
}
