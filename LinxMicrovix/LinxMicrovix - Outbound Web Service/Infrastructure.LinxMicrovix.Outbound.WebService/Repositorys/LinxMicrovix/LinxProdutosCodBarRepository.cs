using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix_Outbound_Web_Service.Entites.LinxMicrovix;
using Domain.LinxMicrovix_Outbound_Web_Service.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix_Outbound_Web_Service.Interfaces.Repositorys.LinxMicrovix;

namespace Infrastructure.LinxMicrovix_Outbound_Web_Service.Repositorys.LinxMicrovix
{
    public class LinxProdutosCodBarRepository : ILinxProdutosCodBarRepository
    {
        private readonly ILinxMicrovixRepositoryBase<LinxProdutosCodBar> _linxMicrovixRepositoryBase;

        public LinxProdutosCodBarRepository(ILinxMicrovixRepositoryBase<LinxProdutosCodBar> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<LinxProdutosCodBar> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new LinxProdutosCodBar());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].cod_produto, records[i].cod_barra, records[i].portal, records[i].timestamp);
                }

                _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                    jobParameter: jobParameter,
                    dataTable: table,
                    dataTableRowsNumber: table.Rows.Count
                );

                return true;
            }
            catch
            {
                throw;
            }
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

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, LinxProdutosCodBar? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [portal], [cod_produto], [cod_barra], [timestamp]) " +
                          "Values " +
                          "(@lastupdateon, @portal, @cod_produto, @cod_barra, @timestamp)";

            try
            {
                return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter: jobParameter, sql: sql, record: record);
            }
            catch
            {
                throw;
            }
        }
    }
}
