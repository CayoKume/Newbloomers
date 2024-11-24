using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosTabelasPrecosRepository : IB2CConsultaProdutosTabelasPrecosRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutosTabelasPrecos> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosTabelasPrecosRepository(ILinxMicrovixRepositoryBase<B2CConsultaProdutosTabelasPrecos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<B2CConsultaProdutosTabelasPrecos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaProdutosTabelasPrecos());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_prod_tab_preco, records[i].id_tabela, records[i].codigoproduto, records[i].precovenda, records[i].timestamp, records[i].portal);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSTABELASPRECOS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSTABELASPRECOS_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPRODUTOSTABELASPRECOS_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPRODUTOSTABELASPRECOS_RAW] AS SOURCE

                                   ON (
			                           TARGET.[ID_PROD_TAB_PRECO] = SOURCE.[ID_PROD_TAB_PRECO]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_PROD_TAB_PRECO] = SOURCE.[ID_PROD_TAB_PRECO],
			                           TARGET.[ID_TABELA] = SOURCE.[ID_TABELA],
			                           TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO],
			                           TARGET.[PRECOVENDA] = SOURCE.[PRECOVENDA],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_PROD_TAB_PRECO] NOT IN (SELECT [ID_PROD_TAB_PRECO] FROM [B2CCONSULTAPRODUTOSTABELASPRECOS_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_PROD_TAB_PRECO], [ID_TABELA], [CODIGOPRODUTO], [PRECOVENDA], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_PROD_TAB_PRECO], SOURCE.[ID_TABELA], SOURCE.[CODIGOPRODUTO], SOURCE.[PRECOVENDA], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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

        public async Task<List<B2CConsultaProdutosTabelasPrecos>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<B2CConsultaProdutosTabelasPrecos> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id_prod_tab_preco}'";
                    else
                        identificadores += $"'{registros[i].id_prod_tab_preco}', ";
                }

                string sql = $"SELECT ID_PROD_TAB_PRECO, TIMESTAMP FROM B2CCONSULTACLIENTES_TRUSTED WHERE ID_PROD_TAB_PRECO IN ({identificadores})";

                return await _linxMicrovixRepositoryBase.GetRegistersExists(jobParameter, sql);
            }
            catch (Exception ex) when (ex is not InternalException && ex is not SQLCommandException)
            {
                throw new InternalException(
                    stage: EnumStages.GetRegistersExists,
                    error: EnumError.Exception,
                    level: EnumMessageLevel.Error,
                    message: "Error when filling identifiers to sql command",
                    exceptionMessage: ex.Message
                );
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
                                                  <Parameter id=""id_tabela"">[id_tabela]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaProdutosTabelasPrecos? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [id_prod_tab_preco], [id_tabela], [codigoproduto], [precovenda], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @id_prod_tab_preco, @id_tabela, @codigoproduto, @precovenda, @timestamp, @portal)";

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
