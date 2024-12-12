using Domain.IntegrationsCore.Entities.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaPalavrasChavePesquisaRepository : IB2CConsultaPalavrasChavePesquisaRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaPalavrasChavePesquisa> _linxMicrovixRepositoryBase;

        public B2CConsultaPalavrasChavePesquisaRepository(ILinxMicrovixRepositoryBase<B2CConsultaPalavrasChavePesquisa> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaPalavrasChavePesquisa> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaPalavrasChavePesquisa());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].id_b2c_palavras_chave_pesquisa, records[i].nome_colecao, records[i].timestamp);
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
            string? sql = $@"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPALAVRASCHAVEPESQUISA_SYNC')
                            BEGIN
                            EXECUTE (
	                            'CREATE PROCEDURE [P_B2CCONSULTAPALAVRASCHAVEPESQUISA_SYNC] AS
	                            BEGIN
		                            MERGE [B2CCONSULTAPALAVRASCHAVEPESQUISA_TRUSTED] AS TARGET
                                    USING [B2CCONSULTAPALAVRASCHAVEPESQUISA_RAW] AS SOURCE

                                    ON (TARGET.[ID_B2C_PALAVRAS_CHAVE_PESQUISA] = SOURCE.[ID_B2C_PALAVRAS_CHAVE_PESQUISA])

                                    WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN
			                            UPDATE SET
			                            TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                            TARGET.[PORTAL] = SOURCE.[PORTAL],
			                            TARGET.[ID_B2C_PALAVRAS_CHAVE_PESQUISA] = SOURCE.[ID_B2C_PALAVRAS_CHAVE_PESQUISA],
			                            TARGET.[NOME_COLECAO] = SOURCE.[NOME_COLECAO],
			                            TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP]

                                    WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_B2C_PALAVRAS_CHAVE_PESQUISA] NOT IN (SELECT [ID_B2C_PALAVRAS_CHAVE_PESQUISA] FROM [B2CCONSULTAPALAVRASCHAVEPESQUISA_TRUSTED]) THEN
			                            INSERT
			                            ([LASTUPDATEON], [PORTAL], [ID_B2C_PALAVRAS_CHAVE_PESQUISA], [NOME_COLECAO], [TIMESTAMP])
			                            VALUES
			                            (SOURCE.[LASTUPDATEON], SOURCE.[PORTAL], SOURCE.[ID_B2C_PALAVRAS_CHAVE_PESQUISA], SOURCE.[NOME_COLECAO], SOURCE.[TIMESTAMP]);
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

        public async Task<List<B2CConsultaPalavrasChavePesquisa>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaPalavrasChavePesquisa> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id_b2c_palavras_chave_pesquisa}'";
                    else
                        identificadores += $"'{registros[i].id_b2c_palavras_chave_pesquisa}', ";
                }

                string sql = $"SELECT ID_B2C_PALAVRAS_CHAVE_PESQUISA, TIMESTAMP FROM B2CCONSULTAPALAVRASCHAVEPESQUISA_TRUSTED WHERE ID_B2C_PALAVRAS_CHAVE_PESQUISA IN ({identificadores})";

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
                        dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        individual = @"<Parameter id=""timestamp"">[0]</Parameter>",
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
