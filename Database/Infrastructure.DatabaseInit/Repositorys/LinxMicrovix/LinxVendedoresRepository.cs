using Dapper;
using Domain.DatabaseInit.Interfaces.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repository.LinxMicrovix
{
    public class LinxVendedoresRepository : ILinxVendedoresRepository
    {
        private readonly ISQLServerConnection? _conn;

        public LinxVendedoresRepository(ISQLServerConnection? conn) =>
            (_conn) = (conn);

        public async Task<bool> CreateTableIfNotExists(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = @$"SELECT DISTINCT * FROM [INFORMATION_SCHEMA].[TABLES] (NOLOCK) WHERE TABLE_NAME LIKE '%{jobParameter.jobName}%'";

            try
            {
                using (var conn = _conn.GetIDbConnection(jobParameter.databaseName))
                {
                    var result = await conn.QueryAsync(sql: sql);

                    if (result.Count() == 0)
                    {
                        conn.CreateTable<LinxVendedores>(tableName: $"{jobParameter.jobName}_raw");
                        conn.CreateTable<LinxVendedores>(tableName: $"{jobParameter.jobName}_trusted");

                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
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
                using (var conn = _conn.GetIDbConnection(jobParameter.databaseName))
                {
                    var result = await conn.ExecuteAsync(sql: sql, commandTimeout: 360);

                    if (result > 0)
                        return true;

                    return false;
                }
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
                var parameter = new {
                    method = jobParameter.jobName,
                    parameters_timestamp = @"<Parameter id=""timestamp"">[0]</Parameter>",
                    parameters_dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                <Parameter id=""data_upd_inicial"">[data_upd_inicial]</Parameter>
                                                <Parameter id=""data_upd_fim"">[data_upd_fim]</Parameter>",
                    parameters_individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                <Parameter id=""cod_vendedor"">[cod_vendedor]</Parameter>",
                    ativo = 1
                };

                string? sql = $"IF NOT EXISTS (SELECT * FROM [{jobParameter.parametersTableName}] WHERE [method] = '{jobParameter.jobName}') " +
                              $"INSERT INTO [{jobParameter.parametersTableName}] ([method], [parameters_timestamp], [parameters_dateinterval], [parameters_individual], [ativo]) " +
                               "VALUES (@method, @parameters_timestamp, @parameters_dateinterval, @parameters_individual, @ativo)";


                using (var conn = _conn.GetIDbConnection(jobParameter.databaseName))
                {
                    var result = await conn.ExecuteAsync(sql: sql, param: parameter, commandTimeout: 360);

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
