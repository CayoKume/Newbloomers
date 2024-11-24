using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosInformacoesRepository : IB2CConsultaProdutosInformacoesRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutosInformacoes> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosInformacoesRepository(ILinxMicrovixRepositoryBase<B2CConsultaProdutosInformacoes> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<B2CConsultaProdutosInformacoes> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaProdutosInformacoes());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_produtos_informacoes, records[i].codigoproduto, records[i].informacoes_produto, records[i].timestamp, records[i].portal);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSINFORMACOES_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSINFORMACOES_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPRODUTOSINFORMACOES_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPRODUTOSINFORMACOES_RAW] AS SOURCE

                                   ON (
			                           TARGET.[ID_PRODUTOS_INFORMACOES] = SOURCE.[ID_PRODUTOS_INFORMACOES]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_PRODUTOS_INFORMACOES] = SOURCE.[ID_PRODUTOS_INFORMACOES],
			                           TARGET.[CODIGO_PRODUTO] = SOURCE.[CODIGO_PRODUTO],
			                           TARGET.[INFORMACOES_PRODUTO] = SOURCE.[INFORMACOES_PRODUTO],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_PRODUTOS_INFORMACOES] NOT IN (SELECT [ID_PRODUTOS_INFORMACOES] FROM [B2CCONSULTAPRODUTOSINFORMACOES_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_PRODUTOS_INFORMACOES], [CODIGO_PRODUTO], [INFORMACOES_PRODUTO], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_PRODUTOS_INFORMACOES], SOURCE.[CODIGO_PRODUTO], SOURCE.[INFORMACOES_PRODUTO], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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

        public async Task<List<B2CConsultaProdutosInformacoes>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<B2CConsultaProdutosInformacoes> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id_produtos_informacoes}'";
                    else
                        identificadores += $"'{registros[i].id_produtos_informacoes}', ";
                }

                string sql = $"SELECT ID_PRODUTOS_INFORMACOES, TIMESTAMP FROM B2CCONSULTACLIENTES_TRUSTED WHERE ID_PRODUTOS_INFORMACOES IN ({identificadores})";

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

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaProdutosInformacoes? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [id_produtos_informacoes], [codigoproduto], [informacoes_produto], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @id_produtos_informacoes, @codigoproduto, @informacoes_produto,, @timestamp, @portal)";

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
