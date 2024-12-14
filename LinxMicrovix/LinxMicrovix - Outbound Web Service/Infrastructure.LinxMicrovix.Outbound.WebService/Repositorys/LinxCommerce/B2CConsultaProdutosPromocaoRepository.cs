using Domain.IntegrationsCore.Entities.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosPromocaoRepository : IB2CConsultaProdutosPromocaoRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutosPromocao> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosPromocaoRepository(ILinxMicrovixRepositoryBase<B2CConsultaProdutosPromocao> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosPromocao> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaProdutosPromocao());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].codigo_promocao, records[i].empresa, records[i].codigoproduto, records[i].preco, records[i].data_inicio, records[i].data_termino, records[i].data_cadastro,
                        records[i].ativa, records[i].codigo_campanha, records[i].promocao_opcional, records[i].timestamp, records[i].referencia, records[i].portal);
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

        public async Task<bool> CreateTableMerge(LinxAPIParam jobParameter)
        {
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSPROMOCOES_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSPROMOCOES_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPRODUTOSPROMOCOES] AS TARGET
                                   USING [B2CCONSULTAPRODUTOSPROMOCOES] AS SOURCE

                                   ON (
			                           TARGET.[CODIGO_PROMOCAO] = SOURCE.[CODIGO_PROMOCAO]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[CODIGO_PROMOCAO] = SOURCE.[CODIGO_PROMOCAO],
			                           TARGET.[EMPRESA] = SOURCE.[EMPRESA],
			                           TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO],
			                           TARGET.[PRECO] = SOURCE.[PRECO],
			                           TARGET.[DATA_INICIO] = SOURCE.[DATA_INICIO],
			                           TARGET.[DATA_TERMINO] = SOURCE.[DATA_TERMINO],
			                           TARGET.[DATA_CADASTRO] = SOURCE.[DATA_CADASTRO],
			                           TARGET.[ATIVA] = SOURCE.[ATIVA],
			                           TARGET.[CODIGO_CAMPANHA] = SOURCE.[CODIGO_CAMPANHA],
			                           TARGET.[PROMOCAO_OPCIONAL] = SOURCE.[PROMOCAO_OPCIONAL],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[REFERENCIA] = SOURCE.[REFERENCIA],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[CODIGO_PROMOCAO] NOT IN (SELECT [CODIGO_PROMOCAO] FROM [B2CCONSULTAPRODUTOSPROMOCOES]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [CODIGO_PROMOCAO], [EMPRESA], [CODIGOPRODUTO], [PRECO], [DATA_INICIO], [DATA_TERMINO], [DATA_CADASTRO], [ATIVA], [CODIGO_CAMPANHA], [PROMOCAO_OPCIONAL], [TIMESTAMP], [REFERENCIA], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[CODIGO_PROMOCAO], SOURCE.[EMPRESA], SOURCE.[CODIGOPRODUTO], SOURCE.[PRECO], SOURCE.[DATA_INICIO], SOURCE.[DATA_TERMINO], SOURCE.[DATA_CADASTRO], SOURCE.[ATIVA], SOURCE.[CODIGO_CAMPANHA], SOURCE.[PROMOCAO_OPCIONAL], SOURCE.[TIMESTAMP],
			                           SOURCE.[REFERENCIA], SOURCE.[PORTAL]);
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

        public async Task<List<B2CConsultaProdutosPromocao>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosPromocao> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].codigoproduto}'";
                    else
                        identificadores += $"'{registros[i].codigoproduto}', ";
                }

                string sql = $"SELECT CODIGOPRODUTO, TIMESTAMP FROM B2CCONSULTAPRODUTOSPROMOCAO WHERE CODIGOPRODUTO IN ({identificadores})";

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

        public async Task<bool> InsertParametersIfNotExists(LinxAPIParam jobParameter)
        {
            try
            {
                return await _linxMicrovixRepositoryBase.InsertParametersIfNotExists(
                    jobParameter: jobParameter,
                    parameter: new
                    {
                        method = jobParameter.jobName,
                        timestamp = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                    <Parameter id=""data_inicio"">[data_inicio]</Parameter>
                                                    <Parameter id=""data_termino"">[data_termino]</Parameter>",
                        individual = @"<Parameter id=""timestamp"">[0]</Parameter>
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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosPromocao? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [codigo_promocao], [empresa], [codigoproduto], [preco], [data_inicio], [data_termino], [data_cadastro], [ativa], [codigo_campanha], [promocao_opcional], [timestamp], [referencia], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @codigo_promocao, @empresa, @codigoproduto, @preco, @data_inicio, @data_termino, @data_cadastro, @ativa, @codigo_campanha, @promocao_opcional, @timestamp, @referencia, @portal)";

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
