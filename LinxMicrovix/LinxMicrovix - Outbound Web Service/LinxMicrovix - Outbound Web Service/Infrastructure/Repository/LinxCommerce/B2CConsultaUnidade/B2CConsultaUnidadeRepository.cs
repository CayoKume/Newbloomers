using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public class B2CConsultaUnidadeRepository : IB2CConsultaUnidadeRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaUnidade> _linxMicrovixRepositoryBase;

        public B2CConsultaUnidadeRepository(ILinxMicrovixRepositoryBase<B2CConsultaUnidade> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<B2CConsultaUnidade> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaUnidade());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].unidade, records[i].timestamp, records[i].portal);
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
                          "ON (TARGET.UNIDADE = SOURCE.UNIDADE) " +
                          "WHEN MATCHED THEN UPDATE SET " +
                          "TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON], " +
                          "TARGET.[UNIDADE] = SOURCE.[UNIDADE], " +
                          "TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP], " +
                          "TARGET.[PORTAL] = SOURCE.[PORTAL] " +
                          "WHEN NOT MATCHED BY TARGET THEN " +
                          "INSERT " +
                          "([LASTUPDATEON], [UNIDADE], [TIMESTAMP], [PORTAL])" +
                          "VALUES " +
                          "(SOURCE.[LASTUPDATEON], SOURCE.[UNIDADE], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);";

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
                        parameters_individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                  <Parameter id=""unidade"">[unidade]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaUnidade? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [unidade], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @unidade, @timestamp, @portal)";

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
