using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosPalavrasChavePesquisaRepository : IB2CConsultaProdutosPalavrasChavePesquisaRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutosPalavrasChavePesquisa> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosPalavrasChavePesquisaRepository(ILinxMicrovixRepositoryBase<B2CConsultaProdutosPalavrasChavePesquisa> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<B2CConsultaProdutosPalavrasChavePesquisa> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaProdutosPalavrasChavePesquisa());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_b2c_palavras_chave_pesquisa_produtos, records[i].id_b2c_palavras_chave_pesquisa, records[i].codigoproduto, records[i].timestamp, records[i].portal);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSPALAVRASCHAVEPESQUISA_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSPALAVRASCHAVEPESQUISA_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPRODUTOSPALAVRASCHAVEPESQUISA_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPRODUTOSPALAVRASCHAVEPESQUISA_RAW] AS SOURCE

                                   ON (
			                           TARGET.[ID_B2C_PALAVRAS_CHAVE_PESQUISA_PRODUTOS] = SOURCE.[ID_B2C_PALAVRAS_CHAVE_PESQUISA_PRODUTOS]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_B2C_PALAVRAS_CHAVE_PESQUISA_PRODUTOS] = SOURCE.[ID_B2C_PALAVRAS_CHAVE_PESQUISA_PRODUTOS],
			                           TARGET.[ID_B2C_PALAVRAS_CHAVE_PESQUISA] = SOURCE.[ID_B2C_PALAVRAS_CHAVE_PESQUISA],
			                           TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_B2C_PALAVRAS_CHAVE_PESQUISA_PRODUTOS] NOT IN (SELECT [ID_B2C_PALAVRAS_CHAVE_PESQUISA_PRODUTOS] FROM [B2CCONSULTAPRODUTOSPALAVRASCHAVEPESQUISA_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_B2C_PALAVRAS_CHAVE_PESQUISA_PRODUTOS], [ID_B2C_PALAVRAS_CHAVE_PESQUISA], [CODIGOPRODUTO], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_B2C_PALAVRAS_CHAVE_PESQUISA_PRODUTOS], SOURCE.[ID_B2C_PALAVRAS_CHAVE_PESQUISA], SOURCE.[CODIGOPRODUTO], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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

        public async Task<List<B2CConsultaProdutosPalavrasChavePesquisa>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<B2CConsultaProdutosPalavrasChavePesquisa> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id_b2c_palavras_chave_pesquisa_produtos}'";
                    else
                        identificadores += $"'{registros[i].id_b2c_palavras_chave_pesquisa_produtos}', ";
                }

                string sql = $"SELECT ID_B2C_PALAVRAS_CHAVE_PESQUISA_PRODUTOS, TIMESTAMP FROM B2CCONSULTACLIENTES_TRUSTED WHERE ID_B2C_PALAVRAS_CHAVE_PESQUISA_PRODUTOS IN ({identificadores})";

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
