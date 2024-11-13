using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public class B2CConsultaPedidosTiposRepository : IB2CConsultaPedidosTiposRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaPedidosTipos> _linxMicrovixRepositoryBase;

        public B2CConsultaPedidosTiposRepository(ILinxMicrovixRepositoryBase<B2CConsultaPedidosTipos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<B2CConsultaPedidosTipos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaPedidosTipos());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_tipo_b2c, records[i].descricao, records[i].pos_timestamp_old, records[i].portal);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPEDIDOSTIPOS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPEDIDOSTIPOS_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPEDIDOSTIPOS_TRUSTED] AS TARGET
		                           USING [B2CCONSULTAPEDIDOSTIPOS_RAW] AS SOURCE

		                           ON (
			                           TARGET.[ID_TIPO_B2C] = SOURCE.[ID_TIPO_B2C]
		                           )

		                           WHEN MATCHED AND TARGET.[POS_TIMESTAMP_OLD] != SOURCE.[POS_TIMESTAMP_OLD] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_TIPO_B2C] = SOURCE.[ID_TIPO_B2C],
			                           TARGET.[DESCRICAO] = SOURCE.[DESCRICAO],
			                           TARGET.[POS_TIMESTAMP_OLD] = SOURCE.[POS_TIMESTAMP_OLD],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

		                           WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_TIPO_B2C] NOT IN (SELECT [ID_TIPO_B2C] FROM [B2CCONSULTAPEDIDOSTIPOS_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_TIPO_B2C], [DESCRICAO], [POS_TIMESTAMP_OLD], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_TIPO_B2C], SOURCE.[DESCRICAO], SOURCE.[POS_TIMESTAMP_OLD], SOURCE.[PORTAL]);
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
                        parameters_individual = @"<Parameter id=""timestamp"">[0]</Parameter>",
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
