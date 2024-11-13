using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public class B2CConsultaSetoresRepository : IB2CConsultaSetoresRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaSetores> _linxMicrovixRepositoryBase;

        public B2CConsultaSetoresRepository(ILinxMicrovixRepositoryBase<B2CConsultaSetores> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<B2CConsultaSetores> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaSetores());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].codigo_setor, records[i].nome_setor, records[i].timestamp, records[i].portal);
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
                          "ON (TARGET.CODIGO_SETOR = SOURCE.CODIGO_SETOR) " +
                          "WHEN MATCHED THEN UPDATE SET " +
                          "TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON], " +
                          "TARGET.[CODIGO_SETOR] = SOURCE.[CODIGO_SETOR], " +
                          "TARGET.[NOME_SETOR] = SOURCE.[NOME_SETOR], " +
                          "TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP], " +
                          "TARGET.[PORTAL] = SOURCE.[PORTAL] " +
                          "WHEN NOT MATCHED BY TARGET THEN " +
                          "INSERT " +
                          "([LASTUPDATEON], [CODIGO_SETOR], [NOME_SETOR], [TIMESTAMP], [PORTAL])" +
                          "VALUES " +
                          "(SOURCE.[LASTUPDATEON], SOURCE.[CODIGO_SETOR], SOURCE.[NOME_SETOR], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);";

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
                                                  <Parameter id=""codigo_setor"">[codigo_setor]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaSetores? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [codigo_setor], [nome_setor], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @codigo_setor, @nome_setor, @timestamp, @portal)";

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
