using Dapper;
using Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxMicrovix.LinxMicrovix
{
    public class LinxClientesFornecRepository : ILinxClientesFornecRepository
    {
        private readonly ISQLServerConnection? _conn;

        public LinxClientesFornecRepository(ISQLServerConnection? conn) =>
            _conn = conn;

        public bool CreateTableIfNotExists(string databaseName, string jobName, string untreatedDatabaseName)
        {
            string? sql = @$"SELECT DISTINCT * FROM [INFORMATION_SCHEMA].[TABLES] (NOLOCK) WHERE TABLE_NAME = '{jobName}'";

            try
            {
                using (var conn = _conn.GetIDbConnection(databaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<LinxClientesFornec>(tableName: $"{jobName}");
                }

                using (var conn = _conn.GetIDbConnection(untreatedDatabaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<LinxClientesFornec>(tableName: $"{jobName}");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> CreateTableMerge(string databaseName, string tableName)
        {
            throw new NotImplementedException() ;
        }

        public async Task<bool> InsertParametersIfNotExists(string jobName, string parametersTableName, string databaseName)
        {
            try
            {
                var parameter = new
                {
                    method = jobName,
                    timestamp = @"<Parameter id=""timestamp"">[0]</Parameter>
                                  <Parameter id=""data_inicial"">[data_inicial]</Parameter>
                                  <Parameter id=""data_fim"">[data_fim]</Parameter>",
                    dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>
                                     <Parameter id=""data_inicial"">[data_inicial]</Parameter>
                                     <Parameter id=""data_fim"">[data_fim]</Parameter>
                                     <Parameter id=""dt_update_inicial"">[dt_update_inicial]</Parameter>
                                     <Parameter id=""dt_update_fim"">[dt_update_fim]</Parameter>",
                    individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                   <Parameter id=""data_inicial"">[data_inicial]</Parameter>
                                   <Parameter id=""data_fim"">[data_fim]</Parameter>
                                   <Parameter id=""doc_cliente"">[doc_cliente]</Parameter>"
                };

                string? sql = $"IF NOT EXISTS (SELECT * FROM [{parametersTableName}] WHERE [method] = '{jobName}') " +
                              $"INSERT INTO [{parametersTableName}] ([method], [parameters_timestamp], [parameters_dateinterval], [parameters_individual]) " +
                               "VALUES (@method, @timestamp, @dateinterval, @individual)";


                using (var conn = _conn.GetIDbConnection(databaseName))
                {
                    var result = await conn.ExecuteAsync(sql: sql, param: parameter, commandTimeout: 360);

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
