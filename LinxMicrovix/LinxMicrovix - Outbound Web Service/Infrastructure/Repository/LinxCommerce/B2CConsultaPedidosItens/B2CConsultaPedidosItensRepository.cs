using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public class B2CConsultaPedidosItensRepository<TEntity> : IB2CConsultaPedidosItensRepository<TEntity> where TEntity : B2CConsultaPedidosItens, new()
    {
        private readonly ILinxMicrovixRepositoryBase<TEntity> _linxMicrovixRepositoryBase;

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<TEntity> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new TEntity());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_pedido_item, records[i].id_pedido, records[i].codigoproduto, records[i].quantidade, records[i].vl_unitario, records[i].timestamp, records[i].portal);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPEDIDOSITENS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPEDIDOSITENS_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPEDIDOSITENS_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPEDIDOSITENS_RAW] AS SOURCE

                                   ON (
			                           TARGET.[ID_PEDIDO_ITEM] = SOURCE.[ID_PEDIDO_ITEM]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_PEDIDO_ITEM] = SOURCE.[ID_PEDIDO_ITEM],
			                           TARGET.[ID_PEDIDO] = SOURCE.[ID_PEDIDO],
			                           TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO],
			                           TARGET.[QUANTIDADE] = SOURCE.[QUANTIDADE],
			                           TARGET.[VL_UNITARIO] = SOURCE.[VL_UNITARIO],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_PEDIDO_ITEM] NOT IN (SELECT [ID_PEDIDO_ITEM] FROM [B2CCONSULTAPEDIDOSITENS_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_PEDIDO_ITEM], [ID_PEDIDO], [CODIGOPRODUTO], [QUANTIDADE], [VL_UNITARIO], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_PEDIDO_ITEM], SOURCE.[ID_PEDIDO], SOURCE.[CODIGOPRODUTO], SOURCE.[QUANTIDADE], SOURCE.[VL_UNITARIO], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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
                                                  <Parameter id=""id_pedido"">[id_pedido]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, TEntity? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [id_pedido_item], [id_pedido], [codigoproduto], [quantidade], [vl_unitario], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @id_pedido_item, @id_pedido, @codigoproduto, @quantidade, @vl_unitario, @timestamp, @portal)";

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
