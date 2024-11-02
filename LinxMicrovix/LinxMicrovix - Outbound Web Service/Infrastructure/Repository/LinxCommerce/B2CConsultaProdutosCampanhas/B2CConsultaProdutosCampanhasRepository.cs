using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public class B2CConsultaProdutosCampanhasRepository<TEntity> : IB2CConsultaProdutosCampanhasRepository<TEntity> where TEntity : B2CConsultaProdutosCampanhas, new()
    {
        private readonly ILinxMicrovixRepositoryBase<TEntity> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosCampanhasRepository(ILinxMicrovixRepositoryBase<TEntity> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<TEntity> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new TEntity());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].codigo_campanha, records[i].nome_campanha, records[i].vigencia_inicio, records[i].vigencia_fim, records[i].observacao, records[i].ativo, records[i].timestamp, records[i].portal);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSCAMPANHAS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSCAMPANHAS_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPRODUTOSCAMPANHAS_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPRODUTOSCAMPANHAS_RAW] AS SOURCE

                                   ON (
			                           TARGET.[CODIGO_CAMPANHA] = SOURCE.[CODIGO_CAMPANHA]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[CODIGO_CAMPANHA] = SOURCE.[CODIGO_CAMPANHA],
			                           TARGET.[NOME_CAMPANHA] = SOURCE.[NOME_CAMPANHA],
			                           TARGET.[VIGENCIA_INICIO] = SOURCE.[VIGENCIA_INICIO],
			                           TARGET.[VIGENCIA_FIM] = SOURCE.[VIGENCIA_FIM],
			                           TARGET.[OBSERVACAO] = SOURCE.[OBSERVACAO],
			                           TARGET.[ATIVO] = SOURCE.[ATIVO],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[CODIGO_CAMPANHA] NOT IN (SELECT [CODIGO_CAMPANHA] FROM [B2CCONSULTAPRODUTOSCAMPANHAS_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [CODIGO_CAMPANHA], [NOME_CAMPANHA], [VIGENCIA_INICIO], [VIGENCIA_FIM], [OBSERVACAO], [ATIVO], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[CODIGO_CAMPANHA], SOURCE.[NOME_CAMPANHA], SOURCE.[VIGENCIA_INICIO], SOURCE.[VIGENCIA_FIM], SOURCE.[OBSERVACAO], SOURCE.[ATIVO], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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
                        parameters_dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                    <Parameter id=""vigencia_inicio"">[vigencia_inicio]</Parameter>
                                                    <Parameter id=""vigencia_fim"">[vigencia_fim]</Parameter>",
                        parameters_individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                  <Parameter id=""codigo_campanha"">[codigo_campanha]</Parameter>",
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
                          "([lastupdateon], [codigo_campanha], [nome_campanha], [vigencia_inicio], [vigencia_fim], [observacao], [ativo], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @codigo_campanha, @nome_campanha, @vigencia_inicio, @vigencia_fim, @observacao, @ativo, @timestamp, @portal)";

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
