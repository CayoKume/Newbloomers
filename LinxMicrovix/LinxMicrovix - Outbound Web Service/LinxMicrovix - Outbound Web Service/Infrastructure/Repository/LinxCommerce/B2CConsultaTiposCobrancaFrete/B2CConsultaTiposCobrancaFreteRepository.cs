using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public class B2CConsultaTiposCobrancaFreteRepository : IB2CConsultaTiposCobrancaFreteRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaTiposCobrancaFrete> _linxMicrovixRepositoryBase;

        public B2CConsultaTiposCobrancaFreteRepository(ILinxMicrovixRepositoryBase<B2CConsultaTiposCobrancaFrete> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<B2CConsultaTiposCobrancaFrete> records)
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

        public async Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = $"MERGE [{jobParameter.tableName}_trusted] AS TARGET " +
                         $"USING [{jobParameter.tableName}_raw] AS SOURCE " +
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
