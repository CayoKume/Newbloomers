using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public class B2CConsultaClientesContatosParentescoRepository : IB2CConsultaClientesContatosParentescoRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaClientesContatosParentesco> _linxMicrovixRepositoryBase;

        public B2CConsultaClientesContatosParentescoRepository(ILinxMicrovixRepositoryBase<B2CConsultaClientesContatosParentesco> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<B2CConsultaClientesContatosParentesco> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaClientesContatosParentesco());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_parentesco, records[i].descricao_parentesco, records[i].timestamp, records[i].portal);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTACLIENTESCONTATOSPARENTESCO_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTACLIENTESCONTATOSPARENTESCO_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTACLIENTESCONTATOSPARENTESCO_TRUSTED] AS TARGET
                                   USING [B2CCONSULTACLIENTESCONTATOSPARENTESCO_RAW] AS SOURCE

                                   ON (
			                           TARGET.[ID_PARENTESCO] = SOURCE.[ID_PARENTESCO]
		                           )

                                   WHEN MATCHED AND SOURCE.[TIMESTAMP] != TARGET.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_PARENTESCO] = SOURCE.[ID_PARENTESCO],
			                           TARGET.[DESCRICAO_PARENTESCO] = SOURCE.[DESCRICAO_PARENTESCO],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_PARENTESCO] NOT IN (SELECT [ID_PARENTESCO] FROM [B2CCONSULTACLIENTESCONTATOSPARENTESCO_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_PARENTESCO], [DESCRICAO_PARENTESCO], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_PARENTESCO], SOURCE.[DESCRICAO_PARENTESCO], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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
                                                  <Parameter id=""id_parentesco"">[id_parentesco]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaClientesContatosParentesco? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [id_parentesco], [descricao_parentesco], [timestamp], [portal])" +
                          "Values " +
                          "(@lastupdateon, @id_parentesco, @descricao_parentesco, @timestamp, @portal)";

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
