using Domain.IntegrationsCore.Entities.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaPlanosParcelasRepository : IB2CConsultaPlanosParcelasRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaPlanosParcelas> _linxMicrovixRepositoryBase;

        public B2CConsultaPlanosParcelasRepository(ILinxMicrovixRepositoryBase<B2CConsultaPlanosParcelas> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaPlanosParcelas> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaPlanosParcelas());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].plano, records[i].ordem_parcela, records[i].prazo_parc, records[i].id_planos_parcelas, records[i].timestamp, records[i].portal);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPLANOSPARCELAS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPLANOSPARCELAS_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPLANOSPARCELAS] AS TARGET
                                   USING [B2CCONSULTAPLANOSPARCELAS] AS SOURCE

                                   ON (
			                           TARGET.[PLANO] = SOURCE.[PLANO]
		                           )
        
		                           WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[PLANO] = SOURCE.[PLANO],
			                           TARGET.[ORDEM_PARCELA] = SOURCE.[ORDEM_PARCELA],
			                           TARGET.[PRAZO_PARC] = SOURCE.[PRAZO_PARC],
			                           TARGET.[ID_PLANOS_PARCELAS] = SOURCE.[ID_PLANOS_PARCELAS],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[PLANO] NOT IN (SELECT [PLANO] FROM [B2CCONSULTAPLANOSPARCELAS]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [PLANO], [ORDEM_PARCELA], [PRAZO_PARC], [ID_PLANOS_PARCELAS], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[PLANO], SOURCE.[ORDEM_PARCELA], SOURCE.[PRAZO_PARC], SOURCE.[ID_PLANOS_PARCELAS], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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

        public async Task<List<B2CConsultaPlanosParcelas>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaPlanosParcelas> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id_planos_parcelas}'";
                    else
                        identificadores += $"'{registros[i].id_planos_parcelas}', ";
                }

                string sql = $"SELECT ID_PLANOS_PARCELAS, TIMESTAMP FROM B2CCONSULTACLIENTES WHERE ID_PLANOS_PARCELAS IN ({identificadores})";

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
                                                  <Parameter id=""plano"">[plano]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaPlanosParcelas? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [plano], [ordem_parcela], [prazo_parc], [id_planos_parcelas], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @plano, @ordem_parcela, @prazo_parc, @id_planos_parcelas, @timestamp, @portal)";

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
