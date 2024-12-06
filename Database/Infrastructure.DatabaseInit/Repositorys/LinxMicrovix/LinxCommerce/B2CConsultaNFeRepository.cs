using Dapper;
using Domain.DatabaseInit.Interfaces.LinxCommerce;
using Domain.IntegrationsCore.Entities.Parameters;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxMicrovix.LinxCommerce
{
    public class B2CConsultaNFeRepository : IB2CConsultaNFeRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaNFeRepository(ISQLServerConnection? conn) =>
            _conn = conn;

        public bool CreateDataTableIfNotExists(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = @$"SELECT DISTINCT * FROM [INFORMATION_SCHEMA].[TABLES] (NOLOCK) WHERE TABLE_NAME = '{jobParameter.jobName}'";

            try
            {
                using (var conn = _conn.GetIDbConnection(jobParameter.databaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<B2CConsultaNFeRepository>(tableName: $"{jobParameter.jobName}");
                }

                using (var conn = _conn.GetIDbConnection(jobParameter.untreatedDatabaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<B2CConsultaNFeRepository>(tableName: $"{jobParameter.jobName}");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTANFE_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTANFE_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTANFE_TRUSTED] AS TARGET
                                   USING [B2CCONSULTANFE_RAW] AS SOURCE

                                   ON (TARGET.[ID_NFE] = SOURCE.[ID_NFE])

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_NFE] = SOURCE.[ID_NFE],
			                           TARGET.[ID_PEDIDO] = SOURCE.[ID_PEDIDO],
			                           TARGET.[DOCUMENTO] = SOURCE.[DOCUMENTO],
			                           TARGET.[DATA_EMISSAO] = SOURCE.[DATA_EMISSAO],
			                           TARGET.[CHAVE_NFE] = SOURCE.[CHAVE_NFE],
			                           TARGET.[SITUACAO] = SOURCE.[SITUACAO],
			                           TARGET.[XML] = SOURCE.[XML],
			                           TARGET.[EXCLUIDO] = SOURCE.[EXCLUIDO],
			                           TARGET.[IDENTIFICADOR_MICROVIX] = SOURCE.[IDENTIFICADOR_MICROVIX],
			                           TARGET.[DT_INSERT] = SOURCE.[DT_INSERT],
			                           TARGET.[VALOR_NOTA] = SOURCE.[VALOR_NOTA],
			                           TARGET.[SERIE] = SOURCE.[SERIE],
			                           TARGET.[FRETE] = SOURCE.[FRETE],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL],
			                           TARGET.[NPROT] = SOURCE.[NPROT],
			                           TARGET.[CODIGO_MODELO_NF] = SOURCE.[CODIGO_MODELO_NF],
			                           TARGET.[JUSTIFICATIVA] = SOURCE.[JUSTIFICATIVA],
			                           TARGET.[TPAMB] = SOURCE.[TPAMB]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_NFE] NOT IN (SELECT [ID_NFE] FROM [B2CCONSULTANFE_TRUSTED]) THEN
                                       INSERT
                                       ([LASTUPDATEON], [ID_NFE], [ID_PEDIDO], [DOCUMENTO], [DATA_EMISSAO], [CHAVE_NFE], [SITUACAO], [XML], [EXCLUIDO], [IDENTIFICADOR_MICROVIX], [DT_INSERT], [VALOR_NOTA], [SERIE], [FRETE], [TIMESTAMP], [PORTAL], [NPROT], [CODIGO_MODELO_NF], [TPAMB])
                                       VALUES
                                       (SOURCE.[LASTUPDATEON], SOURCE.[ID_NFE], SOURCE.[ID_PEDIDO], SOURCE.[DOCUMENTO], SOURCE.[DATA_EMISSAO], SOURCE.[CHAVE_NFE], SOURCE.[SITUACAO], SOURCE.[XML], SOURCE.[EXCLUIDO], SOURCE.[IDENTIFICADOR_MICROVIX], SOURCE.[DT_INSERT],
                                       SOURCE.[VALOR_NOTA], SOURCE.[SERIE], SOURCE.[FRETE], SOURCE.[TIMESTAMP], SOURCE.[PORTAL], SOURCE.[NPROT], SOURCE.[CODIGO_MODELO_NF], SOURCE.[TPAMB]);
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
                var parameter = new
                {
                    method = jobParameter.jobName,
                    timestamp = @"<Parameter id=""timestamp"">[0]</Parameter>",
                    dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>",
                    individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                <Parameter id=""id_pedido"">[id_pedido]</Parameter>",
                    ativo = 1
                };

                string? sql = $"IF NOT EXISTS (SELECT * FROM [{jobParameter.parametersTableName}] WHERE [method] = '{jobParameter.jobName}') " +
                              $"INSERT INTO [{jobParameter.parametersTableName}] ([method], [timestamp], [dateinterval], [individual], [ativo]) " +
                               "VALUES (@method, @timestamp, @dateinterval, @individual, @ativo)";


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
