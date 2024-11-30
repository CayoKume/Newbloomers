using DatabaseInit.Domain.Interfaces.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Parameters;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repositorys.LinxMicrovix
{
    public class LinxProdutosCodBarRepository : ILinxProdutosCodBarRepository
    {
        public LinxProdutosCodBarRepository()
        {
            
        }

        public Task<bool> CreateTableIfNotExists(LinxMicrovixJobParameter jobParameter)
        {
            throw new NotImplementedException(LinxMicrovixJobParameter jobParameter);
        }

        public async Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_LINXPRODUTOSCODBAR_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_LINXPRODUTOSCODBAR_SYNC] AS
	                           BEGIN
		                           MERGE [LINXPRODUTOSCODBAR_TRUSTED] AS TARGET
                                   USING [LINXPRODUTOSCODBAR_RAW] AS SOURCE

                                   ON (
			                           TARGET.[COD_PRODUTO] = SOURCE.[COD_PRODUTO]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[COD_PRODUTO] = SOURCE.[COD_PRODUTO],
			                           TARGET.[COD_BARRA] = SOURCE.[COD_BARRA],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[COD_PRODUTO] NOT IN (SELECT [COD_PRODUTO] FROM [LINXPRODUTOSCODBAR_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [COD_PRODUTO], [COD_BARRA], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[COD_PRODUTO], SOURCE.[COD_BARRA], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
	                           END'
                           )
                           END";

            try
            {
                return await _linxMicrovixRepositoryBase.ExecuteQueryCommand(jobParameter: jobParameter, sql: sql);
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
                return await _linxMicrovixRepositoryBase.InsertParametersIfNotExists(
                    jobParameter: jobParameter,
                    parameter: new
                    {
                        method = jobParameter.jobName,
                        parameters_timestamp = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        parameters_dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        parameters_individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                  <Parameter id=""cod_produto"">[cod_produto]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }
    }
}
