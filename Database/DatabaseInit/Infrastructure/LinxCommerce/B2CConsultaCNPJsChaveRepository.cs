using Dapper;
using DatabaseInit.Domain.Interfaces.LinxCommerce;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repository.LinxCommerce
{
    public class B2CConsultaCNPJsChaveRepository : IB2CConsultaCNPJsChaveRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaCNPJsChaveRepository(ISQLServerConnection? conn) =>
            (_conn) = (conn);

        public async Task<bool> CreateDataTableIfNotExists(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = @$"SELECT DISTINCT * FROM [INFORMATION_SCHEMA].[TABLES] (NOLOCK) WHERE TABLE_NAME LIKE '%{jobParameter.jobName}%'";

            try
            {
                using (var conn = _conn.GetIDbConnection(jobParameter.databaseName))
                {
                    var result = await conn.QueryAsync(sql: sql);

                    if (result.Count() == 0)
                    {
                        conn.CreateTable<B2CConsultaCNPJsChave>(tableName: $"{jobParameter.jobName}_raw");
                        conn.CreateTable<B2CConsultaCNPJsChave>(tableName: $"{jobParameter.jobName}_trusted");

                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTACNPJSCHAVE_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTACNPJSCHAVE_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTACNPJSCHAVE_TRUSTED] AS TARGET
                                   USING [B2CCONSULTACNPJSCHAVE_RAW] AS SOURCE

                                   ON (
			                           TARGET.[CNPJ] = SOURCE.[CNPJ]
		                           )

                                   WHEN MATCHED AND (TARGET.[B2C] != SOURCE.[B2C] OR TARGET.[OMS] != SOURCE.[OMS]) THEN
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[CNPJ] = SOURCE.[CNPJ],
			                           TARGET.[NOME_EMPRESA] = SOURCE.[NOME_EMPRESA],
			                           TARGET.[ID_EMPRESAS_REDE] = SOURCE.[ID_EMPRESAS_REDE],
			                           TARGET.[REDE] = SOURCE.[REDE],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL],
			                           TARGET.[NOME_PORTAL] = SOURCE.[NOME_PORTAL],
			                           TARGET.[EMPRESA] = SOURCE.[EMPRESA],
			                           TARGET.[CLASSIFICACAO_PORTAL] = SOURCE.[CLASSIFICACAO_PORTAL],
			                           TARGET.[B2C] = SOURCE.[B2C],
			                           TARGET.[OMS] = SOURCE.[OMS]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[CNPJ] NOT IN (SELECT [CNPJ] FROM [B2CCONSULTACNPJSCHAVE_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [CNPJ], [NOME_EMPRESA], [ID_EMPRESAS_REDE], [REDE], [PORTAL], [NOME_PORTAL], [EMPRESA], [CLASSIFICACAO_PORTAL], [B2C], [OMS])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[CNPJ], SOURCE.[NOME_EMPRESA], SOURCE.[ID_EMPRESAS_REDE], SOURCE.[REDE], SOURCE.[PORTAL], SOURCE.[NOME_PORTAL], 
			                           SOURCE.[EMPRESA], SOURCE.[CLASSIFICACAO_PORTAL], SOURCE.[B2C], SOURCE.[OMS]);
	                           END'
                           )
                           END";

            try
            {
                using (var conn = _conn.GetIDbConnection(jobParameter.databaseName))
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

        public async Task<bool> InsertParametersIfNotExists(LinxMicrovixJobParameter jobParameter)
        {
            try
            {
                var parameter = new {
                    method = jobParameter.jobName,
                    parameters_timestamp = @"",
                    parameters_dateinterval = @"",
                    parameters_individual = @"<Parameter id=""cod_cliente_erp"">[cod_cliente_erp]</Parameter>",
                    ativo = 1
                };

                string? sql = $"IF NOT EXISTS (SELECT * FROM [{jobParameter.parametersTableName}] WHERE [method] = '{jobParameter.jobName}') " +
                              $"INSERT INTO [{jobParameter.parametersTableName}] ([method], [parameters_timestamp], [parameters_dateinterval], [parameters_individual], [ativo]) " +
                               "VALUES (@method, @parameters_timestamp, @parameters_dateinterval, @parameters_individual, @ativo)";


                using (var conn = _conn.GetIDbConnection(jobParameter.databaseName))
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
