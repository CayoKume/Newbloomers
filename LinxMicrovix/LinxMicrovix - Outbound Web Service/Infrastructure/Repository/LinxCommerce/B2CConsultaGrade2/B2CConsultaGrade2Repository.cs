using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public class B2CConsultaGrade2Repository<TEntity> : IB2CConsultaGrade2Repository<TEntity> where TEntity : B2CConsultaGrade2, new()
    {
        private readonly ILinxMicrovixRepositoryBase<TEntity> _linxMicrovixRepositoryBase;

        public B2CConsultaGrade2Repository(ILinxMicrovixRepositoryBase<TEntity> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<TEntity> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new TEntity());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].codigo_grade2, records[i].nome_grade2, records[i].timestamp, records[i].portal);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAGRADE2_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAGRADE2_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAGRADE2_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAGRADE2_RAW] AS SOURCE

                                   ON (
			                           TARGET.[CODIGO_GRADE2] = SOURCE.[CODIGO_GRADE2]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[CODIGO_GRADE2] = SOURCE.[CODIGO_GRADE2],
			                           TARGET.[NOME_GRADE2] = SOURCE.[NOME_GRADE2],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[CODIGO_GRADE2] NOT IN (SELECT [CODIGO_GRADE2] FROM [B2CCONSULTAGRADE2_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [CODIGO_GRADE2], [NOME_GRADE2], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[CODIGO_GRADE2], SOURCE.[NOME_GRADE2], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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
                                                  <Parameter id=""codigo_grade2"">[codigo_grade2]</Parameter>",
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
                          "([lastupdateon], [codigo_grade2], [nome_grade2], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @codigo_grade2, @nome_grade2, @timestamp, @portal)";

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
