using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public class B2CConsultaClassificacaoRepository : IB2CConsultaClassificacaoRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaClassificacao> _linxMicrovixRepositoryBase;

        public B2CConsultaClassificacaoRepository (ILinxMicrovixRepositoryBase<B2CConsultaClassificacao> linxMicrovixRepositoryBase)  =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<B2CConsultaClassificacao> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaClassificacao());

                for(int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].codigo_classificacao, records[i].nome_classificacao, records[i].timestamp, records[i].portal);
                };

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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTACLASSIFICACAO_SYNC')
                           BEGIN
                           EXECUTE (
                               'CREATE PROCEDURE [P_B2CCONSULTACLASSIFICACAO_SYNC] AS
                               BEGIN
	                               MERGE [B2CCONSULTACLASSIFICACAO_TRUSTED] AS TARGET 
	                               USING [B2CCONSULTACLASSIFICACAO_RAW] AS SOURCE 

	                               ON (
                                        TARGET.[CODIGO_CLASSIFICACAO] = SOURCE.[CODIGO_CLASSIFICACAO]
                                   ) 
	                           
                                   WHEN MATCHED AND SOURCE.[TIMESTAMP] != TARGET.[TIMESTAMP] THEN 
                                       UPDATE SET 
	                                   TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON], 
	                                   TARGET.[CODIGO_CLASSIFICACAO] = SOURCE.[CODIGO_CLASSIFICACAO], 
	                                   TARGET.[NOME_CLASSIFICACAO] = SOURCE.[NOME_CLASSIFICACAO], 
	                                   TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP], 
	                                   TARGET.[PORTAL] = SOURCE.[PORTAL] 
	                           
                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[CODIGO_CLASSIFICACAO] NOT IN (SELECT [CODIGO_CLASSIFICACAO] FROM [B2CCONSULTACLASSIFICACAO_TRUSTED]) THEN 
	                                   INSERT ([LASTUPDATEON], [CODIGO_CLASSIFICACAO], [NOME_CLASSIFICACAO], [TIMESTAMP], [PORTAL])
	                                   VALUES (SOURCE.[LASTUPDATEON], SOURCE.[CODIGO_CLASSIFICACAO], SOURCE.[NOME_CLASSIFICACAO], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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
                    parameter: new { 
                        method = jobParameter.jobName,
                        parameters_timestamp = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        parameters_dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        parameters_individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                  <Parameter id=""codigo_classificacao"">[codigo_classificacao]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaClassificacao? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [codigo_classificacao], [nome_classificacao], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @codigo_classificacao, @nome_classificacao, @timestamp, @portal)";

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
