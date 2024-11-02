using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public class B2CConsultaProdutosDetalhesRepository<TEntity> : IB2CConsultaProdutosDetalhesRepository<TEntity> where TEntity : B2CConsultaProdutosDetalhes, new()
    {
        private readonly ILinxMicrovixRepositoryBase<TEntity> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosDetalhesRepository(ILinxMicrovixRepositoryBase<TEntity> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<TEntity> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new TEntity());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_prod_det, records[i].empresa, records[i].saldo, records[i].controla_lote, records[i].nomeproduto_alternativo, records[i].timestamp, records[i].referencia,
                        records[i].localizacao, records[i].portal, records[i].tempo_preparacao_estoque);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSDETALHES_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSDETALHES_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPRODUTOSDETALHES_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPRODUTOSDETALHES_RAW] AS SOURCE

                                   ON (
			                           TARGET.[ID_PROD_DET] = SOURCE.[ID_PROD_DET]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_PROD_DET] = SOURCE.[ID_PROD_DET],
			                           TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO],
			                           TARGET.[EMPRESA] = SOURCE.[EMPRESA],
			                           TARGET.[SALDO] = SOURCE.[SALDO],
			                           TARGET.[CONTROLE_LOTE] = SOURCE.[CONTROLE_LOTE],
			                           TARGET.[NOMEPRODUTO_ALTERNATIVO] = SOURCE.[NOMEPRODUTO_ALTERNATIVO],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[REFERENCIA] = SOURCE.[REFERENCIA],
			                           TARGET.[LOCALIZACAO] = SOURCE.[LOCALIZACAO],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL],
			                           TARGET.[TEMPO_PREPARACAO_ESTOQUE] = SOURCE.[TEMPO_PREPARACAO_ESTOQUE]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_PROD_DET] NOT IN (SELECT [ID_PROD_DET] FROM [B2CCONSULTAPRODUTOSDETALHES_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_PROD_DET], [CODIGOPRODUTO], [EMPRESA], [SALDO], [CONTROLE_LOTE], [NOMEPRODUTO_ALTERNATIVO], [TIMESTAMP], [REFERENCIA], [LOCALIZACAO], [PORTAL], [TEMPO_PREPARACAO_ESTOQUE])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_PROD_DET], SOURCE.[CODIGOPRODUTO], SOURCE.[EMPRESA], SOURCE.[SALDO], SOURCE.[CONTROLE_LOTE], SOURCE.[NOMEPRODUTO_ALTERNATIVO], SOURCE.[TIMESTAMP], SOURCE.[REFERENCIA], SOURCE.[LOCALIZACAO], SOURCE.[PORTAL], SOURCE.[TEMPO_PREPARACAO_ESTOQUE]);
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
                                                  <Parameter id=""codigoproduto"">[codigoproduto]</Parameter>",
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
                          "([lastupdateon], [id_prod_det], [codigoproduto], [empresa], [saldo], [controla_lote], [nomeproduto_alternativo], [timestamp], [referencia], [localizacao], [portal], [tempo_preparacao_estoque]) " +
                          "Values " +
                          "(@lastupdateon, @id_prod_det, @codigoproduto, @empresa, @saldo, @controla_lote, @nomeproduto_alternativo, @timestamp, @referencia, @localizacao, @portal, @tempo_preparacao_estoque)";

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
