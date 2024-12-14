using Domain.IntegrationsCore.Entities.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaTiposCobrancaFreteRepository : IB2CConsultaTiposCobrancaFreteRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaTiposCobrancaFrete> _linxMicrovixRepositoryBase;

        public B2CConsultaTiposCobrancaFreteRepository(ILinxMicrovixRepositoryBase<B2CConsultaTiposCobrancaFrete> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaTiposCobrancaFrete> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaTiposCobrancaFrete());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].codigo_tipo_cobranca_frete, records[i].nome_tipo_cobranca_frete, records[i].timestamp, records[i].portal);
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
            string? sql = $"MERGE [{jobParameter.tableName}] AS TARGET " +
                         $"USING [{jobParameter.tableName}] AS SOURCE " +
                          "ON (TARGET.CODIG_TIPO_COBRANCA_FRETE = SOURCE.CODIG_TIPO_COBRANCA_FRETE) " +
                          "WHEN MATCHED THEN UPDATE SET " +
                          "TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON], " +
                          "TARGET.[CODIG_TIPO_COBRANCA_FRETE] = SOURCE.[CODIG_TIPO_COBRANCA_FRETE], " +
                          "TARGET.[NOME_TIPO_COBRANCA_FRETE] = SOURCE.[NOME_TIPO_COBRANCA_FRETE], " +
                          "TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP], " +
                          "TARGET.[PORTAL] = SOURCE.[PORTAL] " +
                          "WHEN NOT MATCHED BY TARGET THEN " +
                          "INSERT " +
                          "([LASTUPDATEON], [CODIG_TIPO_COBRANCA_FRETE], [NOME_TIPO_COBRANCA_FRETE], [TIMESTAMP], [PORTAL])" +
                          "VALUES " +
                          "(SOURCE.[LASTUPDATEON], SOURCE.[CODIG_TIPO_COBRANCA_FRETE], SOURCE.[NOME_TIPO_COBRANCA_FRETE], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);";

            try
            {
                return await _linxMicrovixRepositoryBase.ExecuteQueryCommand(jobParameter: jobParameter, sql: sql);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<B2CConsultaTiposCobrancaFrete>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaTiposCobrancaFrete> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].codigo_tipo_cobranca_frete}'";
                    else
                        identificadores += $"'{registros[i].codigo_tipo_cobranca_frete}', ";
                }

                string sql = $"SELECT CODIGO_TIPO_COBRANCA_FRETE, TIMESTAMP FROM B2CCONSULTATIPOSCOBRANCAFRETE WHERE CODIGO_TIPO_COBRANCA_FRETE IN ({identificadores})";

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
