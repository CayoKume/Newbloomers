using Dapper;
using Domain.DatabaseInit.Interfaces.LinxCommerce;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using System.Reflection.Metadata;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxMicrovix.LinxCommerce
{
    public class B2CConsultaProdutosAssociadosRepository : IB2CConsultaProdutosAssociadosRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaProdutosAssociadosRepository(ISQLServerConnection? conn) =>
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
                        conn.CreateTable<B2CConsultaProdutosAssociados>(tableName: $"{jobParameter.jobName}");
                }

                using (var conn = _conn.GetIDbConnection(jobParameter.untreatedDatabaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<B2CConsultaProdutosAssociados>(tableName: $"{jobParameter.jobName}");
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSASSOCIADOS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSASSOCIADOS_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPRODUTOSASSOCIADOS_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPRODUTOSASSOCIADOS_RAW] AS SOURCE

                                   ON (
			                           TARGET.[ID] = SOURCE.[ID]
		                           )
        
		                           WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID] = SOURCE.[ID],
			                           TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO],
			                           TARGET.[CODIGOPRODUTO_ASSOCIADO] = SOURCE.[CODIGOPRODUTO_ASSOCIADO],
			                           TARGET.[COEFICIENTE_DESCONTO] = SOURCE.[COEFICIENTE_DESCONTO],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL],
			                           TARGET.[QTDE_ITEM] = SOURCE.[QTDE_ITEM],
			                           TARGET.[ITEM_OBRIGATORIO] = SOURCE.[ITEM_OBRIGATORIO]
        
		                           WHEN NOT MATCHED BY TARGET AND SOURCE.[ID] NOT IN (SELECT [ID] FROM [B2CCONSULTAPRODUTOSASSOCIADOS_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID], [CODIGOPRODUTO], [CODIGOPRODUTO_ASSOCIADO], [COEFICIENTE_DESCONTO], [TIMESTAMP], [PORTAL], [QTDE_ITEM], [ITEM_OBRIGATORIO])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID], SOURCE.[CODIGOPRODUTO], SOURCE.[CODIGOPRODUTO_ASSOCIADO], SOURCE.[COEFICIENTE_DESCONTO], SOURCE.[TIMESTAMP], SOURCE.[PORTAL], SOURCE.[QTDE_ITEM], SOURCE.[ITEM_OBRIGATORIO]);
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
                                                <Parameter id=""codigoproduto"">[codigoproduto]</Parameter>",
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
