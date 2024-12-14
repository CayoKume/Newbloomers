using Dapper;
using Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxCommerce;

using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxMicrovix.LinxCommerce
{
    public class B2CConsultaFornecedoresRepository : IB2CConsultaFornecedoresRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaFornecedoresRepository(ISQLServerConnection? conn) =>
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
                        conn.CreateTable<B2CConsultaFornecedores>(tableName: $"{jobName}");
                }

                using (var conn = _conn.GetIDbConnection(untreatedDatabaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<B2CConsultaFornecedores>(tableName: $"{jobName}");
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAFORNECEDORES_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAFORNECEDORES_SYNC] AS
	                           BEGIN
		                           MERGE [LINX_MICROVIX_COMMERCE].[dbo].[B2CCONSULTAFORNECEDORES] AS TARGET
                                   USING [UNTREATED].[dbo].[B2CCONSULTAFORNECEDORES] AS SOURCE

                                   ON (
			                           TARGET.COD_FORNECEDOR = SOURCE.COD_FORNECEDOR
		                           )

                                   WHEN MATCHED AND SOURCE.[TIMESTAMP] != TARGET.[TIMESTAMP] THEN UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[COD_FORNECEDOR] = SOURCE.[COD_FORNECEDOR],
			                           TARGET.[NOME] = SOURCE.[NOME],
			                           TARGET.[NOME_FANTASIA] = SOURCE.[NOME_FANTASIA],
			                           TARGET.[TIPO_PESSOA] = SOURCE.[TIPO_PESSOA],
			                           TARGET.[TIPO_FORNECEDOR] = SOURCE.[TIPO_FORNECEDOR],
			                           TARGET.[ENDERECO] = SOURCE.[ENDERECO],
			                           TARGET.[NUMERO_RUA] = SOURCE.[NUMERO_RUA],
			                           TARGET.[BAIRRO] = SOURCE.[BAIRRO],
			                           TARGET.[CEP] = SOURCE.[CEP],
			                           TARGET.[CIDADE] = SOURCE.[CIDADE],
			                           TARGET.[UF] = SOURCE.[UF],
			                           TARGET.[DOCUMENTO] = SOURCE.[DOCUMENTO],
			                           TARGET.[FONE] = SOURCE.[FONE],
			                           TARGET.[EMAIL] = SOURCE.[EMAIL],
			                           TARGET.[PAIS] = SOURCE.[PAIS],
			                           TARGET.[OBS] = SOURCE.[OBS],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND [COD_FORNECEDOR] NOT IN (SELECT [COD_FORNECEDOR] FROM [LINX_MICROVIX_COMMERCE].[dbo].[B2CCONSULTAFORNECEDORES]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [COD_FORNECEDOR], [NOME], [NOME_FANTASIA], [TIPO_PESSOA], [TIPO_FORNECEDOR], [ENDERECO], [NUMERO_RUA], [BAIRRO], [CEP], [CIDADE], [UF], [DOCUMENTO], [FONE], [EMAIL], [PAIS], [OBS], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[COD_FORNECEDOR], SOURCE.[NOME], SOURCE.[NOME_FANTASIA], SOURCE.[TIPO_PESSOA], SOURCE.[TIPO_FORNECEDOR], SOURCE.[ENDERECO], SOURCE.[NUMERO_RUA], SOURCE.[BAIRRO], SOURCE.[CEP], SOURCE.[CIDADE], SOURCE.[UF], 
			                           SOURCE.[DOCUMENTO], SOURCE.[FONE], SOURCE.[EMAIL], SOURCE.[PAIS], SOURCE.[OBS], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
	                           END'
                           )
                           END";

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
