using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosTagsRepository : IB2CConsultaProdutosTagsRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutosTags> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosTagsRepository(ILinxMicrovixRepositoryBase<B2CConsultaProdutosTags> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<B2CConsultaProdutosTags> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaProdutosTags());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].id_b2c_tags_produtos, records[i].id_b2c_tags, records[i].codigoproduto, records[i].timestamp, records[i].portal);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSTAGS_SYNC')
                            BEGIN
                            EXECUTE (
	                            'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSTAGS_SYNC] AS
	                            BEGIN
		                            MERGE [B2CCONSULTAPRODUTOSTAGS_TRUSTED] AS TARGET
                                    USING [B2CCONSULTAPRODUTOSTAGS_RAW] AS SOURCE

                                    ON (
			                            TARGET.[ID_B2C_TAGS_PRODUTOS] = SOURCE.[ID_B2C_TAGS_PRODUTOS]
		                            )

                                    WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN
			                            UPDATE SET
			                            TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                            TARGET.[ID_B2C_TAGS_PRODUTOS] = SOURCE.[ID_B2C_TAGS_PRODUTOS],
			                            TARGET.[ID_B2C_TAGS] = SOURCE.[ID_B2C_TAGS],
			                            TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO],
			                            TARGET.[DESCRICAO_B2C_TAGS] = SOURCE.[DESCRICAO_B2C_TAGS],
			                            TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                            TARGET.[PORTAL] = SOURCE.[PORTAL]

                                    WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_B2C_TAGS_PRODUTOS] NOT IN (SELECT [ID_B2C_TAGS_PRODUTOS] FROM [B2CCONSULTAPRODUTOSTAGS_TRUSTED]) THEN
			                            INSERT
			                            ([LASTUPDATEON], [ID_B2C_TAGS_PRODUTOS], [ID_B2C_TAGS], [CODIGOPRODUTO], [DESCRICAO_B2C_TAGS], [TIMESTAMP], [PORTAL])
			                            VALUES
			                            (SOURCE.[LASTUPDATEON], SOURCE.[ID_B2C_TAGS_PRODUTOS], SOURCE.[ID_B2C_TAGS], SOURCE.[CODIGOPRODUTO], SOURCE.[DESCRICAO_B2C_TAGS], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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

        public async Task<List<B2CConsultaProdutosTags>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<B2CConsultaProdutosTags> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id_b2c_tags}'";
                    else
                        identificadores += $"'{registros[i].id_b2c_tags}', ";
                }

                string sql = $"SELECT ID_B2C_TAGS, TIMESTAMP FROM B2CCONSULTAPRODUTOSTAGS_TRUSTED WHERE ID_B2C_TAGS IN ({identificadores})";

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
