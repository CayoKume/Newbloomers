using Dapper;
using Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxCommerce;

using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxMicrovix.LinxCommerce
{
    public class B2CConsultaTransportadoresRepository : IB2CConsultaTransportadoresRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaTransportadoresRepository(ISQLServerConnection? conn) =>
            _conn = conn;

        public bool CreateDataTableIfNotExists(string databaseName, string jobName, string untreatedDatabaseName)
        {
            string? sql = @$"SELECT DISTINCT * FROM [INFORMATION_SCHEMA].[TABLES] (NOLOCK) WHERE TABLE_NAME = '{jobName}'";

            try
            {
                using (var conn = _conn.GetIDbConnection(databaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<B2CConsultaTransportadores>(tableName: $"{jobName}");
                }

                using (var conn = _conn.GetIDbConnection(untreatedDatabaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<B2CConsultaTransportadores>(tableName: $"{jobName}");
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
            string? sql = $"MERGE [{tableName}_trusted] AS TARGET " +
                         $"USING [{tableName}_raw] AS SOURCE " +
                          "ON (TARGET.COD_TRANSPORTADOR = SOURCE.COD_TRANSPORTADOR) " +
                          "WHEN MATCHED THEN UPDATE SET " +
                          "TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON], " +
                          "TARGET.[COD_TRANSPORTADOR] = SOURCE.[COD_TRANSPORTADOR], " +
                          "TARGET.[NOME] = SOURCE.[NOME], " +
                          "TARGET.[NOME_FANTASIA] = SOURCE.[NOME_FANTASIA], " +
                          "TARGET.[TIPO_PESSOA] = SOURCE.[TIPO_PESSOA], " +
                          "TARGET.[TIPO_TRANSPORTADOR] = SOURCE.[TIPO_TRANSPORTADOR], " +
                          "TARGET.[ENDRECO] = SOURCE.[ENDRECO], " +
                          "TARGET.[NUMERO_RUA] = SOURCE.[NUMERO_RUA], " +
                          "TARGET.[BAIRRO] = SOURCE.[BAIRRO], " +
                          "TARGET.[CEP] = SOURCE.[CEP], " +
                          "TARGET.[CIDADE] = SOURCE.[CIDADE], " +
                          "TARGET.[UF] = SOURCE.[UF], " +
                          "TARGET.[DOCUMENTO] = SOURCE.[DOCUMENTO], " +
                          "TARGET.[FONE] = SOURCE.[FONE], " +
                          "TARGET.[EMAIL] = SOURCE.[EMAIL], " +
                          "TARGET.[PAIS] = SOURCE.[PAIS], " +
                          "TARGET.[OBS] = SOURCE.[OBS], " +
                          "TARGET.[parameters_timestamp] = SOURCE.[parameters_timestamp], " +
                          "TARGET.[PORTAL] = SOURCE.[PORTAL] " +
                          "WHEN NOT MATCHED BY TARGET THEN " +
                          "INSERT " +
                          "([LASTUPDATEON], [COD_TRANSPORTADOR], [NOME], [NOME_FANTASIA], [TIPO_PESSOA], [TIPO_TRANSPORTADOR], [ENDRECO], [NUMERO_RUA], [BAIRRO], [CEP], [CIDADE], [UF], [DOCUMENTO], [FONE], [EMAIL], [PAIS], [OBS], [parameters_timestamp], [PORTAL])" +
                          "VALUES " +
                          "(SOURCE.[LASTUPDATEON], SOURCE.[COD_TRANSPORTADOR], SOURCE.[NOME], SOURCE.[NOME_FANTASIA], SOURCE.[TIPO_PESSOA], SOURCE.[TIPO_TRANSPORTADOR], SOURCE.[ENDRECO], SOURCE.[NUMERO_RUA], SOURCE.[BAIRRO], SOURCE.[CEP], SOURCE.[CIDADE], SOURCE.[UF], " +
                          "SOURCE.[DOCUMENTO], SOURCE.[FONE], SOURCE.[EMAIL], SOURCE.[PAIS], SOURCE.[OBS], SOURCE.[parameters_timestamp], SOURCE.[PORTAL]);";

            try
            {
                using (var conn = _conn.GetIDbConnection(databaseName))
                {
                    var result = await conn.ExecuteAsync(sql: sql, commandTimeout: 360);

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

        public async Task<bool> InsertParametersIfNotExists(string jobName, string parametersTableName, string databaseName)
        {
            try
            {
                var parameter = new
                {
                    method = jobName,
                    timestamp = @"<Parameter id=""timestamp"">[0]</Parameter>",
                    dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>",
                    individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                <Parameter id=""documento"">[documento]</Parameter>"
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
