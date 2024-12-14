using Domain.IntegrationsCore.Entities.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaCodigoRastreioRepository : IB2CConsultaCodigoRastreioRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaCodigoRastreio> _linxMicrovixRepositoryBase;

        public B2CConsultaCodigoRastreioRepository(ILinxMicrovixRepositoryBase<B2CConsultaCodigoRastreio> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaCodigoRastreio> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaCodigoRastreio());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_pedido, records[i].documento, records[i].serie, records[i].codigo_rastreio, records[i].sequencia_volume, 
                        records[i].timestamp, records[i].portal);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTACODIGORASTREIO_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTACODIGORASTREIO_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTACODIGORASTREIO] AS TARGET
                                   USING [B2CCONSULTACODIGORASTREIO] AS SOURCE

                                   ON (
			                           TARGET.[ID_PEDIDO] = SOURCE.[ID_PEDIDO]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
                                       UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_PEDIDO] = SOURCE.[ID_PEDIDO],
			                           TARGET.[DOCUMENTO] = SOURCE.[DOCUMENTO],
			                           TARGET.[SERIE] = SOURCE.[SERIE],
			                           TARGET.[CODIGO_RASTREIO] = SOURCE.[CODIGO_RASTREIO],
			                           TARGET.[SEQUENCIA_VOLUME] = SOURCE.[SEQUENCIA_VOLUME],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_PEDIDO] NOT IN (SELECT [ID_PEDIDO] FROM [B2CCONSULTACODIGORASTREIO]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_PEDIDO], [DOCUMENTO], [SERIE], [CODIGO_RASTREIO], [SEQUENCIA_VOLUME], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_PEDIDO], SOURCE.[DOCUMENTO], SOURCE.[SERIE], SOURCE.[CODIGO_RASTREIO], SOURCE.[SEQUENCIA_VOLUME], 
			                           SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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

        public async Task<List<B2CConsultaCodigoRastreio>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaCodigoRastreio> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].codigo_rastreio}'";
                    else
                        identificadores += $"'{registros[i].codigo_rastreio}', ";
                }

                string sql = $"SELECT CODIGO_RASTREIO, TIMESTAMP FROM B2CCONSULTACODIGORASTREIO WHERE CODIGO_RASTREIO IN ({identificadores})";

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
                        individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                  <Parameter id=""id_pedido"">[id_pedido]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaCodigoRastreio? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [id_pedido], [documento], [serie], [codigo_rastreio], [sequencia_volume], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @id_pedido, @documento, @serie, @codigo_rastreio, @sequencia_volume, @timestamp, @portal)";

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
