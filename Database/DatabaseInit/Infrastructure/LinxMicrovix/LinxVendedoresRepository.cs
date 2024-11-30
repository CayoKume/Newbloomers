using DatabaseInit.Domain.Interfaces.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Parameters;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repositorys.LinxMicrovix
{
    public class LinxVendedoresRepository : ILinxVendedoresRepository
    {
        public LinxVendedoresRepository()
        {
            
        }

        public Task<bool> CreateTableIfNotExists(LinxMicrovixJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = $"MERGE [{jobParameter.tableName}_trusted] AS TARGET " +
                         $"USING [{jobParameter.tableName}_raw] AS SOURCE " +
                          "ON ( " +
                          "TARGET.COD_VENDEDOR = SOURCE.COD_VENDEDOR " +
                          ") " +
                          "WHEN MATCHED THEN UPDATE SET " +
                          "TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON], " +
                          "TARGET.[PORTAL] = SOURCE.[PORTAL], " +
                          "TARGET.[NOME_VENDEDOR] = SOURCE.[NOME_VENDEDOR], " +
                          "TARGET.[TIPO_VENDEDOR] = SOURCE.[TIPO_VENDEDOR], " +
                          "TARGET.[END_VEND_RUA] = SOURCE.[END_VEND_RUA], " +
                          "TARGET.[END_VEND_NUMERO] = SOURCE.[END_VEND_NUMERO], " +
                          "TARGET.[END_VEND_COMPLEMENTO] = SOURCE.[END_VEND_COMPLEMENTO], " +
                          "TARGET.[END_VEND_BAIRRO] = SOURCE.[END_VEND_BAIRRO], " +
                          "TARGET.[END_VEND_CEP] = SOURCE.[END_VEND_CEP], " +
                          "TARGET.[END_VEND_CIDADE] = SOURCE.[END_VEND_CIDADE], " +
                          "TARGET.[END_VEND_UF] = SOURCE.[END_VEND_UF], " +
                          "TARGET.[FONE_VENDEDOR] = SOURCE.[FONE_VENDEDOR], " +
                          "TARGET.[MAIL_VENDEDOR] = SOURCE.[MAIL_VENDEDOR], " +
                          "TARGET.[DT_UPD] = SOURCE.[DT_UPD], " +
                          "TARGET.[CPF_VENDEDOR] = SOURCE.[CPF_VENDEDOR], " +
                          "TARGET.[ATIVO] = SOURCE.[ATIVO], " +
                          "TARGET.[DATA_ADMISSAO] = SOURCE.[DATA_ADMISSAO], " +
                          "TARGET.[DATA_SAIDA] = SOURCE.[DATA_SAIDA], " +
                          "TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP], " +
                          "TARGET.[MATRICULA] = SOURCE.[MATRICULA], " +
                          "TARGET.[ID_TIPO_VENDA] = SOURCE.[ID_TIPO_VENDA], " +
                          "TARGET.[DESCRICAO_TIPO_VENDA] = SOURCE.[DESCRICAO_TIPO_VENDA], " +
                          "TARGET.[CARGO] = SOURCE.[CARGO] " +
                          "WHEN NOT MATCHED THEN " +
                          "INSERT " +
                          "([LASTUPDATEON], [PORTAL], [COD_VENDEDOR], [NOME_VENDEDOR], [TIPO_VENDEDOR], [END_VEND_RUA], [END_VEND_NUMERO], [END_VEND_COMPLEMENTO], [END_VEND_BAIRRO], [END_VEND_CEP], " + 
                          "[END_VEND_CIDADE], [END_VEND_UF], [FONE_VENDEDOR], [MAIL_VENDEDOR], [DT_UPD], [CPF_VENDEDOR], [ATIVO], [DATA_ADMISSAO], [DATA_SAIDA], [TIMESTAMP], [MATRICULA], [ID_TIPO_VENDA], " + 
                          "[DESCRICAO_TIPO_VENDA], [CARGO])" +
                          "VALUES " +
                          "(SOURCE.[LASTUPDATEON], SOURCE.[PORTAL], SOURCE.[COD_VENDEDOR], SOURCE.[NOME_VENDEDOR], SOURCE.[TIPO_VENDEDOR], SOURCE.[END_VEND_RUA], SOURCE.[END_VEND_NUMERO], SOURCE.[END_VEND_COMPLEMENTO], " + 
                          "SOURCE.[END_VEND_BAIRRO], SOURCE.[END_VEND_CEP], SOURCE.[END_VEND_CIDADE], SOURCE.[END_VEND_UF], SOURCE.[FONE_VENDEDOR], SOURCE.[MAIL_VENDEDOR], SOURCE.[DT_UPD], SOURCE.[CPF_VENDEDOR], " + 
                          "SOURCE.[ATIVO], SOURCE.[DATA_ADMISSAO], SOURCE.[DATA_SAIDA], SOURCE.[TIMESTAMP], SOURCE.[MATRICULA], SOURCE.[ID_TIPO_VENDA], SOURCE.[DESCRICAO_TIPO_VENDA], SOURCE.[CARGO]);";

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
                        parameters_dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                    <Parameter id=""data_upd_inicial"">[data_upd_inicial]</Parameter>
                                                    <Parameter id=""data_upd_fim"">[data_upd_fim]</Parameter>",
                        parameters_individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                  <Parameter id=""cod_vendedor"">[cod_vendedor]</Parameter>",
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
