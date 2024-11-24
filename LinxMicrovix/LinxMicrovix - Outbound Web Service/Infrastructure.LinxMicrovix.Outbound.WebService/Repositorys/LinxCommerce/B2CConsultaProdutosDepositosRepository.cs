using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosDepositosRepository : IB2CConsultaProdutosDepositosRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutosDepositos> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosDepositosRepository(ILinxMicrovixRepositoryBase<B2CConsultaProdutosDepositos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<B2CConsultaProdutosDepositos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaProdutosDepositos());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_deposito, records[i].nome_deposito, records[i].disponivel, records[i].disponivel_transferencia, records[i].disponivel_franquias, records[i].timestamp, records[i].portal);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSDEPOSITOS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSDEPOSITOS_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPRODUTOSDEPOSITOS_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPRODUTOSDEPOSITOS_RAW] AS SOURCE

                                   ON (
			                           TARGET.[ID_DEPOSITO] = SOURCE.[ID_DEPOSITO]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_DEPOSITO] = SOURCE.[ID_DEPOSITO],
			                           TARGET.[NOME_DEPOSITO] = SOURCE.[NOME_DEPOSITO],
			                           TARGET.[DISPONIVEL] = SOURCE.[DISPONIVEL],
			                           TARGET.[DISPONIVEL_TRANSFERENCIA] = SOURCE.[DISPONIVEL_TRANSFERENCIA],
			                           TARGET.[DISPONIVEL_FRANQUIAS] = SOURCE.[DISPONIVEL_FRANQUIAS],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_DEPOSITO] NOT IN (SELECT [ID_DEPOSITO] FROM [B2CCONSULTAPRODUTOSDEPOSITOS_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_DEPOSITO], [NOME_DEPOSITO], [DISPONIVEL], [DISPONIVEL_TRANSFERENCIA], [DISPONIVEL_FRANQUIAS], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_DEPOSITO], SOURCE.[NOME_DEPOSITO], SOURCE.[DISPONIVEL], SOURCE.[DISPONIVEL_TRANSFERENCIA], SOURCE.[DISPONIVEL_FRANQUIAS], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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

        public async Task<List<B2CConsultaProdutosDepositos>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<B2CConsultaProdutosDepositos> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id_deposito}'";
                    else
                        identificadores += $"'{registros[i].id_deposito}', ";
                }

                string sql = $"SELECT ID_DEPOSITO, TIMESTAMP FROM B2CCONSULTAPRODUTOSDEPOSITOS_TRUSTED WHERE ID_DEPOSITO IN ({identificadores})";

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
                                                  <Parameter id=""id_deposito"">[id_deposito]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaProdutosDepositos? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [id_deposito], [nome_deposito], [disponivel], [disponivel_transferencia], [disponivel_franquias], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @id_deposito, @nome_deposito, @disponivel, @disponivel_transferencia, @disponivel_franquias, @timestamp, @portal)";

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
