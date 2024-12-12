using Dapper;
using Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxCommerce;

using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxMicrovix.LinxCommerce
{
    public class B2CConsultaEmpresasRepository : IB2CConsultaEmpresasRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaEmpresasRepository(ISQLServerConnection? conn) =>
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
                        conn.CreateTable<B2CConsultaEmpresas>(tableName: $"{jobName}");
                }

                using (var conn = _conn.GetIDbConnection(untreatedDatabaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<B2CConsultaEmpresas>(tableName: $"{jobName}");
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAEMPRESAS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAEMPRESAS_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAEMPRESAS_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAEMPRESAS_RAW] AS SOURCE

                                   ON (
			                           TARGET.[EMPRESA] = SOURCE.[EMPRESA]
		                           )

                                   WHEN MATCHED AND TARGET.[parameters_timestamp] != SOURCE.[parameters_timestamp] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[EMPRESA] = SOURCE.[EMPRESA],
			                           TARGET.[NOME_EMP] = SOURCE.[NOME_EMP],
			                           TARGET.[CNPJ_EMP] = SOURCE.[CNPJ_EMP],
			                           TARGET.[END_UNIDADE] = SOURCE.[END_UNIDADE],
			                           TARGET.[COMPLEMENTO_END_UNIDADE] = SOURCE.[COMPLEMENTO_END_UNIDADE],
			                           TARGET.[NR_RUA_UNIDADE] = SOURCE.[NR_RUA_UNIDADE],
			                           TARGET.[BAIRRO_UNIDADE] = SOURCE.[BAIRRO_UNIDADE],
			                           TARGET.[CEP_UNIDADE] = SOURCE.[CEP_UNIDADE],
			                           TARGET.[CIDADE_UNIDADE] = SOURCE.[CIDADE_UNIDADE],
			                           TARGET.[UF_UNIDADE] = SOURCE.[UF_UNIDADE],
			                           TARGET.[EMAIL_UNIDADE] = SOURCE.[EMAIL_UNIDADE],
			                           TARGET.[parameters_timestamp] = SOURCE.[parameters_timestamp],
			                           TARGET.[DATA_CRIACAO] = SOURCE.[DATA_CRIACAO],
			                           TARGET.[CENTRO_DISTRIBUICAO] = SOURCE.[CENTRO_DISTRIBUICAO],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[EMPRESA] NOT IN (SELECT [EMPRESA] FROM [B2CCONSULTAEMPRESAS_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [EMPRESA], [NOME_EMP], [CNPJ_EMP], [END_UNIDADE], [COMPLEMENTO_END_UNIDADE], [NR_RUA_UNIDADE], [BAIRRO_UNIDADE], [CEP_UNIDADE], [CIDADE_UNIDADE], [UF_UNIDADE], [EMAIL_UNIDADE], [parameters_timestamp],
			                           [DATA_CRIACAO], [CENTRO_DISTRIBUICAO], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[EMPRESA], SOURCE.[NOME_EMP], SOURCE.[CNPJ_EMP], SOURCE.[END_UNIDADE], SOURCE.[COMPLEMENTO_END_UNIDADE], SOURCE.[NR_RUA_UNIDADE], SOURCE.[BAIRRO_UNIDADE], SOURCE.[CEP_UNIDADE], SOURCE.[CIDADE_UNIDADE],
			                           SOURCE.[UF_UNIDADE], SOURCE.[EMAIL_UNIDADE], SOURCE.[parameters_timestamp], SOURCE.[DATA_CRIACAO], SOURCE.[CENTRO_DISTRIBUICAO], SOURCE.[PORTAL]);
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
                    individual = @"<Parameter id=""timestamp"">[0]</Parameter>"
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
