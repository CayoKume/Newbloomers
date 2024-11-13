using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix_Outbound_Web_Service.Entites.LinxCommerce;
using Domain.LinxMicrovix_Outbound_Web_Service.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix_Outbound_Web_Service.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix_Outbound_Web_Service.Repository.LinxCommerce
{
    public class B2CConsultaNFeSituacaoRepository : IB2CConsultaNFeSituacaoRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaNFeSituacao> _linxMicrovixRepositoryBase;

        public B2CConsultaNFeSituacaoRepository(ILinxMicrovixRepositoryBase<B2CConsultaNFeSituacao> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<B2CConsultaNFeSituacao> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaNFeSituacao());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_nfe_situacao, records[i].descricao, records[i].timestamp, records[i].portal);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTANFESITUACAO_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTANFESITUACAO_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTANFESITUACAO_TRUSTED] AS TARGET
                                   USING [B2CCONSULTANFESITUACAO_RAW] AS SOURCE

                                   ON (
			                           TARGET.[ID_NFE_SITUACAO] = SOURCE.[ID_NFE_SITUACAO]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_NFE_SITUACAO] = SOURCE.[ID_NFE_SITUACAO],
			                           TARGET.[DESCRICAO] = SOURCE.[DESCRICAO],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_NFE_SITUACAO] NOT IN (SELECT [ID_NFE_SITUACAO] FROM [B2CCONSULTANFESITUACAO_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_NFE_SITUACAO], [DESCRICAO], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_NFE_SITUACAO], SOURCE.[DESCRICAO], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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
