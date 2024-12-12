using Domain.IntegrationsCore.Entities.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosFlagsRepository : IB2CConsultaProdutosFlagsRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutosFlags> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosFlagsRepository(ILinxMicrovixRepositoryBase<B2CConsultaProdutosFlags> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosFlags> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaProdutosFlags());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].id_b2c_flags_produtos, records[i].id_b2c_flags, records[i].codigoproduto, records[i].timestamp, records[i].descricao_b2c_flags);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSFLAGS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSFLAGS_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPRODUTOSFLAGS_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPRODUTOSFLAGS_RAW] AS SOURCE

                                   ON (
			                           TARGET.[ID_B2C_FLAGS_PRODUTOS] = SOURCE.[ID_B2C_FLAGS_PRODUTOS]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_B2C_FLAGS_PRODUTOS] = SOURCE.[ID_B2C_FLAGS_PRODUTOS],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL],
			                           TARGET.[ID_B2C_FLAGS] = SOURCE.[ID_B2C_FLAGS],
			                           TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[DESCRICAO_B2C_FLAGS] = SOURCE.[DESCRICAO_B2C_FLAGS]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_B2C_FLAGS_PRODUTOS] NOT IN (SELECT [ID_B2C_FLAGS_PRODUTOS] FROM [B2CCONSULTAPRODUTOSFLAGS_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_B2C_FLAGS_PRODUTOS], [PORTAL], [ID_B2C_FLAGS], [CODIGOPRODUTO], [TIMESTAMP], [DESCRICAO_B2C_FLAGS])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_B2C_FLAGS_PRODUTOS], SOURCE.[PORTAL], SOURCE.[ID_B2C_FLAGS], SOURCE.[CODIGOPRODUTO], SOURCE.[TIMESTAMP], SOURCE.[DESCRICAO_B2C_FLAGS]);
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

        public async Task<List<B2CConsultaProdutosFlags>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosFlags> registros)
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

                string sql = $"SELECT CODIGOPRODUTO, TIMESTAMP FROM B2CCONSULTAPRODUTOSFLAGS_TRUSTED WHERE CODIGOPRODUTO IN ({identificadores})";

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
