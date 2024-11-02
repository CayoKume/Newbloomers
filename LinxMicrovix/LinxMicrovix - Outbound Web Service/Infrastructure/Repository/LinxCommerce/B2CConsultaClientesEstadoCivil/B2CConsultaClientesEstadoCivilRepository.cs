using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public class B2CConsultaClientesEstadoCivilRepository<TEntity> : IB2CConsultaClientesEstadoCivilRepository<TEntity> where TEntity : B2CConsultaClientesEstadoCivil, new()
    {
        private readonly ILinxMicrovixRepositoryBase<TEntity> _linxMicrovixRepositoryBase;

        public B2CConsultaClientesEstadoCivilRepository(ILinxMicrovixRepositoryBase<TEntity> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<TEntity> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new TEntity());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_estado_civil, records[i].estado_civil, records[i].timestamp, records[i].portal);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTACLIENTESESTADOCIVIL_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTACLIENTESESTADOCIVIL_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTACLIENTESESTADOCIVIL_TRUSTED] AS TARGET
		                           USING [B2CCONSULTACLIENTESESTADOCIVIL_RAW] AS SOURCE

		                           ON (
			                           TARGET.[ID_ESTADO_CIVIL] = SOURCE.[ID_ESTADO_CIVIL]
		                           )

		                           WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_ESTADO_CIVIL] = SOURCE.[ID_ESTADO_CIVIL],
			                           TARGET.[ESTADO_CIVIL] = SOURCE.[ESTADO_CIVIL],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

		                           WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_ESTADO_CIVIL] NOT IN (SELECT [ID_ESTADO_CIVIL] FROM [B2CCONSULTACLIENTESESTADOCIVIL_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_ESTADO_CIVIL], [ESTADO_CIVIL], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_ESTADO_CIVIL], SOURCE.[ESTADO_CIVIL], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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
