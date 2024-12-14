using Domain.IntegrationsCore.Entities.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaFormasPagamentoRepository : IB2CConsultaFormasPagamentoRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaFormasPagamento> _linxMicrovixRepositoryBase;

        public B2CConsultaFormasPagamentoRepository(ILinxMicrovixRepositoryBase<B2CConsultaFormasPagamento> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaFormasPagamento> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaFormasPagamento());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].cod_forma_pgto, records[i].timestamp, records[i].portal);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAFORMASPAGAMENTO_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAFORMASPAGAMENTO_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAFORMASPAGAMENTO] AS TARGET
                                   USING [B2CCONSULTAFORMASPAGAMENTO] AS SOURCE

                                   ON (
			                           TARGET.[COD_FORMA_PGTO] = SOURCE.[COD_FORMA_PGTO]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[COD_FORMA_PGTO] = SOURCE.[COD_FORMA_PGTO],
			                           TARGET.[FORMA_PGTO] = SOURCE.[FORMA_PGTO],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[COD_FORMA_PGTO] NOT IN (SELECT [COD_FORMA_PGTO] FROM [B2CCONSULTAFORMASPAGAMENTO]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [COD_FORMA_PGTO], [FORMA_PGTO], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[COD_FORMA_PGTO], SOURCE.[FORMA_PGTO], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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

        public async Task<List<B2CConsultaFormasPagamento>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaFormasPagamento> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].cod_forma_pgto}'";
                    else
                        identificadores += $"'{registros[i].cod_forma_pgto}', ";
                }

                string sql = $"SELECT COD_FORMA_PGTO, TIMESTAMP FROM B2CCONSULTAFORMASPAGAMENTO WHERE COD_FORMA_PGTO IN ({identificadores})";

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
