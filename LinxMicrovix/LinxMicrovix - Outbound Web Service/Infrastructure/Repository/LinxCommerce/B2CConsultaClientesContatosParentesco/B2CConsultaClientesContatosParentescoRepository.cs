using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public class B2CConsultaClientesContatosParentescoRepository<TEntity> : IB2CConsultaClientesContatosParentescoRepository<TEntity> where TEntity : B2CConsultaClientesContatosParentesco, new()
    {
        private readonly ILinxMicrovixRepositoryBase<TEntity> _linxMicrovixRepositoryBase;

        public B2CConsultaClientesContatosParentescoRepository(ILinxMicrovixRepositoryBase<TEntity> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(JobParameter jobParameter, List<TEntity> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new TEntity());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_parentesco, records[i].descricao_parentesco, records[i].timestamp, records[i].portal);
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

        public async Task<bool> ExecuteTableMerge(JobParameter jobParameter)
        {
            string sql = $"MERGE [{jobParameter.tableName}_trusted] AS TARGET " +
                         $"USING [{jobParameter.tableName}_raw] AS SOURCE " +
                         "ON (TARGET.ID_PARENTESCO = SOURCE.ID_PARENTESCO) " +
                         "WHEN MATCHED THEN UPDATE SET " +
                         "TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON], " +
                         "TARGET.[ID_PARENTESCO] = SOURCE.[ID_PARENTESCO], " +
                         "TARGET.[DESCRICAO_PARENTESCO] = SOURCE.[DESCRICAO_PARENTESCO], " +
                         "TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP], " +
                         "TARGET.[PORTAL] = SOURCE.[PORTAL] " +
                         "WHEN NOT MATCHED BY TARGET THEN " +
                         "INSERT" +
                         "([LASTUPDATEON], [ID_PARENTESCO], [DESCRICAO_PARENTESCO], [TIMESTAMP], [PORTAL]) " +
                         "VALUES " +
                         "(SOURCE.[LASTUPDATEON], SOURCE.[ID_PARENTESCO], SOURCE.[DESCRICAO_PARENTESCO], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);";

            try
            {
                return await _linxMicrovixRepositoryBase.ExecuteQueryCommand(jobParameter: jobParameter, sql: sql);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertParametersIfNotExists(JobParameter jobParameter)
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
                                                  <Parameter id=""id_parentesco"">[id_parentesco]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(JobParameter jobParameter, TEntity? record)
        {
            string sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [id_parentesco], [descricao_parentesco], [timestamp], [portal])" +
                          "Values " +
                          "(@lastupdateon, @id_parentesco, @descricao_parentesco, @timestamp, @portal)";

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
