using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public class B2CConsultaProdutosDetalhesDepositosRepository : IB2CConsultaProdutosDetalhesDepositosRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutosDetalhesDepositos> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosDetalhesDepositosRepository(ILinxMicrovixRepositoryBase<B2CConsultaProdutosDetalhesDepositos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<B2CConsultaProdutosDetalhesDepositos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaProdutosDetalhesDepositos());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].codigoproduto, records[i].empresa, records[i].id_deposito, records[i].saldo, records[i].timestamp, records[i].portal, records[i].deposito, records[i].tempo_preparacao_estoque);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSDETALHESDEPOSITOS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSDETALHESDEPOSITOS_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPRODUTOSDETALHESDEPOSITOS_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPRODUTOSDETALHESDEPOSITOS_RAW] AS SOURCE

                                   ON (
			                           TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO],
			                           TARGET.[EMPRESA] = SOURCE.[EMPRESA],
			                           TARGET.[ID_DEPOSITO] = SOURCE.[ID_DEPOSITO],
			                           TARGET.[SALDO] = SOURCE.[SALDO],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL],
			                           TARGET.[DEPOSITO] = SOURCE.[DEPOSITO],
			                           TARGET.[TEMPO_PREPARACAO_ESTOQUE] = SOURCE.[TEMPO_PREPARACAO_ESTOQUE]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[CODIGOPRODUTO] NOT IN (SELECT [CODIGOPRODUTO] FROM [B2CCONSULTAPRODUTOSDETALHESDEPOSITOS_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [CODIGOPRODUTO], [EMPRESA], [ID_DEPOSITO], [SALDO], [TIMESTAMP], [PORTAL], [DEPOSITO], [TEMPO_PREPARACAO_ESTOQUE])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[CODIGOPRODUTO], SOURCE.[EMPRESA], SOURCE.[ID_DEPOSITO], SOURCE.[SALDO], SOURCE.[TIMESTAMP], SOURCE.[PORTAL], SOURCE.[DEPOSITO], SOURCE.[TEMPO_PREPARACAO_ESTOQUE]);
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
                                                  <Parameter id=""codigoproduto"">[codigoproduto]</Parameter>
                                                  <Parameter id=""deposito"">[deposito]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaProdutosDetalhesDepositos? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [codigoproduto], [empresa], [id_deposito], [saldo], [timestamp], [portal], [deposito], [tempo_preparacao_estoque]) " +
                          "Values " +
                          "(@lastupdateon, @codigoproduto, @empresa, @id_deposito, @saldo, @timestamp, @portal, @deposito, @tempo_preparacao_estoque)";

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
