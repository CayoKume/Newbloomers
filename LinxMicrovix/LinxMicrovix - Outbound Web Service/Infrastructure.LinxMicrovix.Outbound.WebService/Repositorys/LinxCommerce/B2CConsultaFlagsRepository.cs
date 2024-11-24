using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaFlagsRepository : IB2CConsultaFlagsRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaFlags> _linxMicrovixRepositoryBase;

        public B2CConsultaFlagsRepository(ILinxMicrovixRepositoryBase<B2CConsultaFlags> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<B2CConsultaFlags> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaFlags());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].id_b2c_flags, records[i].descricao, records[i].timestamp);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAFLAGS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAFLAGS_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAFLAGS_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAFLAGS_RAW] AS SOURCE

                                   ON (
			                           TARGET.[ID_B2C_FLAGS] = SOURCE.[ID_B2C_FLAGS]
		                           )

                                   WHEN MATCHED THEN UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL],
			                           TARGET.[ID_B2C_FLAGS] = SOURCE.[ID_B2C_FLAGS],
			                           TARGET.[DESCRICAO] = SOURCE.[DESCRICAO],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_B2C_FLAGS] NOT IN (SELECT [ID_B2C_FLAGS] FROM [B2CCONSULTAFLAGS_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [PORTAL], [ID_B2C_FLAGS], [DESCRICAO], [TIMESTAMP])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[PORTAL], SOURCE.[ID_B2C_FLAGS], SOURCE.[DESCRICAO], SOURCE.[TIMESTAMP]);
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

        public async Task<List<B2CConsultaFlags>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<B2CConsultaFlags> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id_b2c_flags}'";
                    else
                        identificadores += $"'{registros[i].id_b2c_flags}', ";
                }

                string sql = $"SELECT ID_B2C_FLAGS, TIMESTAMP FROM B2CCONSULTAFLAGS_TRUSTED WHERE ID_B2C_FLAGS IN ({identificadores})";

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
