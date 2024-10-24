using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public class B2CConsultaClientesContatosRepository<TEntity> : IB2CConsultaClientesContatosRepository<TEntity> where TEntity : B2CConsultaClientesContatos, new()
    {
        private readonly ILinxMicrovixRepositoryBase<TEntity> _linxMicrovixRepositoryBase;

        public B2CConsultaClientesContatosRepository(ILinxMicrovixRepositoryBase<TEntity> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(JobParameter jobParameter, List<TEntity> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new TEntity());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_clientes_contatos, records[i].id_contato_b2c, records[i].nome_contato, records[i].data_nasc_contato, records[i].sexo_contato,
                        records[i].id_parentesco, records[i].fone_contato, records[i].celular_contato, records[i].email_contato, records[i].cod_cliente_erp, records[i].timestamp, records[i].portal);
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
                         "ON (TARGET.ID_CLIENTES_CONTATOS = SOURCE.ID_CLIENTES_CONTATOS) " +
                         "WHEN MATCHED THEN UPDATE SET " +
                         "TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON], " +
                         "TARGET.[ID_CLIENTES_CONTATOS] = SOURCE.[ID_CLIENTES_CONTATOS], " +
                         "TARGET.[ID_CONTATO_B2C] = SOURCE.[ID_CONTATO_B2C], " +
                         "TARGET.[NOME_CONTATO] = SOURCE.[NOME_CONTATO], " +
                         "TARGET.[DATA_NASC_CONTATO] = SOURCE.[DATA_NASC_CONTATO], " +
                         "TARGET.[SEXO_CONTATO] = SOURCE.[SEXO_CONTATO], " +
                         "TARGET.[ID_PARENTESCO] = SOURCE.[ID_PARENTESCO], " +
                         "TARGET.[FONE_CONTATO] = SOURCE.[FONE_CONTATO], " +
                         "TARGET.[CELULAR_CONTATO] = SOURCE.[CELULAR_CONTATO], " +
                         "TARGET.[EMAIL_CONTATO] = SOURCE.[EMAIL_CONTATO], " +
                         "TARGET.[COD_CLIENTE_ERP] = SOURCE.[COD_CLIENTE_ERP], " +
                         "TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP], " +
                         "TARGET.[PORTAL] = SOURCE.[PORTAL] " +
                         "WHEN NOT MATCHED BY TARGET THEN " +
                         "INSERT" +
                         "([LASTUPDATEON], [ID_CLIENTES_CONTATOS], [ID_CONTATO_B2C], [NOME_CONTATO], [DATA_NASC_CONTATO], [SEXO_CONTATO], " +
                         "[ID_PARENTESCO], [FONE_CONTATO], [CELULAR_CONTATO], [EMAIL_CONTATO], [COD_CLIENTE_ERP], [TIMESTAMP], [PORTAL]) " +
                         "VALUES " +
                         "(SOURCE.[LASTUPDATEON], SOURCE.[ID_CLIENTES_CONTATOS], SOURCE.[ID_CONTATO_B2C], SOURCE.[NOME_CONTATO], SOURCE.[DATA_NASC_CONTATO], SOURCE.[SEXO_CONTATO], " +
                         "SOURCE.[ID_PARENTESCO], SOURCE.[FONE_CONTATO], SOURCE.[CELULAR_CONTATO], SOURCE.[EMAIL_CONTATO], SOURCE.[COD_CLIENTE_ERP], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);";

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

        public async Task<bool> InsertRecord(JobParameter jobParameter, TEntity? record)
        {
            string sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [id_clientes_contatos], [id_contato_b2c], [nome_contato], [data_nasc_contato], [sexo_contato], " + 
                          "[id_parentesco], [fone_contato], [celular_contato], [email_contato], [cod_cliente_erp], [timestamp], [portal])" +
                          "Values " +
                          "(@lastupdateon, @id_clientes_contatos, @id_contato_b2c, @nome_contato, @data_nasc_contato, @sexo_contato, @id_parentesco, " + 
                          "@fone_contato, @celular_contato, @email_contato, @cod_cliente_erp, @timestamp, @portal)";

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
