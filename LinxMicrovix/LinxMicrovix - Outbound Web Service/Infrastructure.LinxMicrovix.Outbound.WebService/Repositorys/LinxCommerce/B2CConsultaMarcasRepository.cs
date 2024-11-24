using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaMarcasRepository : IB2CConsultaMarcasRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaMarcas> _linxMicrovixRepositoryBase;

        public B2CConsultaMarcasRepository(ILinxMicrovixRepositoryBase<B2CConsultaMarcas> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<B2CConsultaMarcas> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaMarcas());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].codigo_marca, records[i].nome_marca, records[i].timestamp, records[i].linhas, records[i].portal);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAMARCAS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAMARCAS_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAMARCAS_TRUSTED] AS TARGET
		                           USING [B2CCONSULTAMARCAS_RAW] AS SOURCE

		                           ON (TARGET.[CODIGO_MARCA] = SOURCE.[CODIGO_MARCA])

		                           WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[CODIGO_MARCA] = SOURCE.[CODIGO_MARCA],
			                           TARGET.[NOME_MARCA] = SOURCE.[NOME_MARCA],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[LINHAS] = SOURCE.[LINHAS],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

		                           WHEN NOT MATCHED BY TARGET AND SOURCE.[CODIGO_MARCA] NOT IN (SELECT [CODIGO_MARCA] FROM [B2CCONSULTAMARCAS_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [CODIGO_MARCA], [NOME_MARCA], [TIMESTAMP], [LINHAS], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[CODIGO_MARCA], SOURCE.[NOME_MARCA], SOURCE.[TIMESTAMP], SOURCE.[LINHAS], SOURCE.[PORTAL]);
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

        public async Task<List<B2CConsultaMarcas>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<B2CConsultaMarcas> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].codigo_marca}'";
                    else
                        identificadores += $"'{registros[i].codigo_marca}', ";
                }

                string sql = $"SELECT CODIGO_MARCA, TIMESTAMP FROM B2CCONSULTAMARCAS_TRUSTED WHERE CODIGO_MARCA IN ({identificadores})";

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
                                                  <Parameter id=""codigo_marca"">[codigo_marca]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaMarcas? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [codigo_marca], [nome_marca], [timestamp], [linhas], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @codigo_marca, @nome_marca, @timestamp, @linhas, @portal)";

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
