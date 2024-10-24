using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public class B2CConsultaEmpresasRepository<TEntity> : IB2CConsultaEmpresasRepository<TEntity> where TEntity : B2CConsultaEmpresas, new()
    {
        private readonly ILinxMicrovixRepositoryBase<TEntity> _linxMicrovixRepositoryBase;

        public B2CConsultaEmpresasRepository(ILinxMicrovixRepositoryBase<TEntity> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(JobParameter jobParameter, List<TEntity> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new TEntity());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].empresa, records[i].nome_emp, records[i].cnpj_emp, records[i].end_unidade, records[i].complemento_end_unidade,
                        records[i].nr_rua_unidade, records[i].bairro_unidade, records[i].cep_unidade, records[i].cidade_unidade, records[i].uf_unidade, records[i].email_unidade, records[i].timestamp, 
                        records[i].data_criacao, records[i].centro_distribuicao, records[i].portal);
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
                          "ON (TARGET.EMPRESA = SOURCE.EMPRESA) " +
                          "WHEN MATCHED THEN UPDATE SET " +
                          "TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON], " +
                          "TARGET.[EMPRESA] = SOURCE.[EMPRESA], " +
                          "TARGET.[NOME_EMP] = SOURCE.[NOME_EMP], " +
                          "TARGET.[CNPJ_EMP] = SOURCE.[CNPJ_EMP], " +
                          "TARGET.[END_UNIDADE] = SOURCE.[END_UNIDADE], " +
                          "TARGET.[COMPLEMENTO_END_UNIDADE] = SOURCE.[COMPLEMENTO_END_UNIDADE], " +
                          "TARGET.[NR_RUA_UNIDADE] = SOURCE.[NR_RUA_UNIDADE], " +
                          "TARGET.[BAIRRO_UNIDADE] = SOURCE.[BAIRRO_UNIDADE], " +
                          "TARGET.[CEP_UNIDADE] = SOURCE.[CEP_UNIDADE], " +
                          "TARGET.[CIDADE_UNIDADE] = SOURCE.[CIDADE_UNIDADE], " +
                          "TARGET.[UF_UNIDADE] = SOURCE.[UF_UNIDADE], " +
                          "TARGET.[EMAIL_UNIDADE] = SOURCE.[EMAIL_UNIDADE], " +
                          "TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP], " +
                          "TARGET.[DATA_CRIACAO] = SOURCE.[DATA_CRIACAO], " +
                          "TARGET.[CENTRO_DISTRIBUICAO] = SOURCE.[CENTRO_DISTRIBUICAO], " +
                          "TARGET.[PORTAL] = SOURCE.[PORTAL] " +
                          "WHEN NOT MATCHED BY TARGET THEN " +
                          "INSERT " +
                          "([LASTUPDATEON], [EMPRESA], [NOME_EMP], [CNPJ_EMP], [END_UNIDADE], [COMPLEMENTO_END_UNIDADE], [NR_RUA_UNIDADE], [BAIRRO_UNIDADE], [CEP_UNIDADE], [CIDADE_UNIDADE], [UF_UNIDADE], [EMAIL_UNIDADE], [TIMESTAMP], " +
                          "[DATA_CRIACAO], [CENTRO_DISTRIBUICAO], [PORTAL])" +
                          "VALUES " +
                          "(SOURCE.[LASTUPDATEON], SOURCE.[EMPRESA], SOURCE.[NOME_EMP], SOURCE.[CNPJ_EMP], SOURCE.[END_UNIDADE], SOURCE.[COMPLEMENTO_END_UNIDADE], SOURCE.[NR_RUA_UNIDADE], SOURCE.[BAIRRO_UNIDADE], SOURCE.[CEP_UNIDADE], SOURCE.[CIDADE_UNIDADE], " +
                          "SOURCE.[UF_UNIDADE], SOURCE.[EMAIL_UNIDADE], SOURCE.[TIMESTAMP], SOURCE.[DATA_CRIACAO], SOURCE.[CENTRO_DISTRIBUICAO], SOURCE.[PORTAL]);";

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
    }
}
