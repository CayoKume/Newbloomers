using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisValoresRepository : IB2CConsultaProdutosCamposAdicionaisValoresRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutosCamposAdicionaisValores> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosCamposAdicionaisValoresRepository(ILinxMicrovixRepositoryBase<B2CConsultaProdutosCamposAdicionaisValores> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<B2CConsultaProdutosCamposAdicionaisValores> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaProdutosCamposAdicionaisValores());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_campo_valor, records[i].codigoproduto, records[i].id_campo_detalhe, records[i].timestamp, records[i].portal);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSCAMPOSADICIONAISVALORES_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSCAMPOSADICIONAISVALORES_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPRODUTOSCAMPOSADICIONAISVALORES_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPRODUTOSCAMPOSADICIONAISVALORES_RAW] AS SOURCE

                                   ON (
			                           TARGET.[ID_CAMPO_VALOR] = SOURCE.[ID_CAMPO_VALOR]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_CAMPO_VALOR] = SOURCE.[ID_CAMPO_VALOR],
			                           TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO],
			                           TARGET.[ID_CAMPO_DETALHE] = SOURCE.[ID_CAMPO_DETALHE],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_CAMPO_VALOR] NOT IN (SELECT [ID_CAMPO_VALOR] FROM [B2CCONSULTAPRODUTOSCAMPOSADICIONAISVALORES_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_CAMPO_VALOR], [CODIGOPRODUTO], [ID_CAMPO_DETALHE], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_CAMPO_VALOR], SOURCE.[CODIGOPRODUTO], SOURCE.[ID_CAMPO_DETALHE], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaProdutosCamposAdicionaisValores? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [id_campo_valor], [codigoproduto], [id_campo_detalhe], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @id_campo_valor, @codigoproduto, @id_campo_detalhe, @timestamp, @portal)";

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
