using Dapper;
using Domain.DatabaseInit.Interfaces.LinxMicrovix.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxMicrovix.Parameters
{
    public class LinxAPIParamRepository : ILinxAPIParamRepository
    {
        private readonly ISQLServerConnection _sqlServerConnection;

        public LinxAPIParamRepository(ISQLServerConnection sqlServerConnection) =>
            _sqlServerConnection = sqlServerConnection;

        public bool CreateTableIfNotExists(string databaseName, string jobName)
        {
            string? sql = @$"SELECT DISTINCT * FROM [INFORMATION_SCHEMA].[TABLES] (NOLOCK) WHERE TABLE_NAME = '{jobName}'";

            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection(databaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<LinxAPIParam>(tableName: $"{jobName}");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
