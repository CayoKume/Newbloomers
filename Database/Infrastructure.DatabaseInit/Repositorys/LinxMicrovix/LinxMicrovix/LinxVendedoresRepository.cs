using Dapper;
using Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxMicrovix.LinxMicrovix
{
    public class LinxVendedoresRepository : ILinxVendedoresRepository
    {
        private readonly ISQLServerConnection? _conn;

        public LinxVendedoresRepository(ISQLServerConnection? conn) =>
            _conn = conn;

        public bool CreateTableIfNotExists(string databaseName, string jobName, string untreatedDatabaseName)
        {
            string? sql = @$"SELECT DISTINCT * FROM [INFORMATION_SCHEMA].[TABLES] (NOLOCK) WHERE TABLE_NAME = '{jobName}' AND TABLE_SCHEMA = 'linx_microvix_erp'";

            try
            {
                using (var conn = _conn.GetIDbConnection(databaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count()  == 0)
                        conn.CreateTable<LinxVendedores>();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            sql = @$"SELECT DISTINCT * FROM [INFORMATION_SCHEMA].[TABLES] (NOLOCK) WHERE TABLE_NAME = '{jobName}' AND TABLE_SCHEMA = 'untreated'";

            try
            {
                using (var conn = _conn.GetIDbConnection(untreatedDatabaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<Domain.DatabaseInit.Entites.LinxMicrovix.LinxMicrovix.LinxVendedores>();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return true;
        }

        public async Task<bool> CreateTableMerge(string databaseName, string tableName)
        {
            string? sql = $"MERGE [{tableName}_trusted] AS TARGET " +
                         $"USING [{tableName}_raw] AS SOURCE " +
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
                          "TARGET.[parameters_timestamp] = SOURCE.[parameters_timestamp], " +
                          "TARGET.[MATRICULA] = SOURCE.[MATRICULA], " +
                          "TARGET.[ID_TIPO_VENDA] = SOURCE.[ID_TIPO_VENDA], " +
                          "TARGET.[DESCRICAO_TIPO_VENDA] = SOURCE.[DESCRICAO_TIPO_VENDA], " +
                          "TARGET.[CARGO] = SOURCE.[CARGO] " +
                          "WHEN NOT MATCHED THEN " +
                          "INSERT " +
                          "([LASTUPDATEON], [PORTAL], [COD_VENDEDOR], [NOME_VENDEDOR], [TIPO_VENDEDOR], [END_VEND_RUA], [END_VEND_NUMERO], [END_VEND_COMPLEMENTO], [END_VEND_BAIRRO], [END_VEND_CEP], " +
                          "[END_VEND_CIDADE], [END_VEND_UF], [FONE_VENDEDOR], [MAIL_VENDEDOR], [DT_UPD], [CPF_VENDEDOR], [DATA_ADMISSAO], [DATA_SAIDA], [parameters_timestamp], [MATRICULA], [ID_TIPO_VENDA], " +
                          "[DESCRICAO_TIPO_VENDA], [CARGO])" +
                          "VALUES " +
                          "(SOURCE.[LASTUPDATEON], SOURCE.[PORTAL], SOURCE.[COD_VENDEDOR], SOURCE.[NOME_VENDEDOR], SOURCE.[TIPO_VENDEDOR], SOURCE.[END_VEND_RUA], SOURCE.[END_VEND_NUMERO], SOURCE.[END_VEND_COMPLEMENTO], " +
                          "SOURCE.[END_VEND_BAIRRO], SOURCE.[END_VEND_CEP], SOURCE.[END_VEND_CIDADE], SOURCE.[END_VEND_UF], SOURCE.[FONE_VENDEDOR], SOURCE.[MAIL_VENDEDOR], SOURCE.[DT_UPD], SOURCE.[CPF_VENDEDOR], " +
                          "SOURCE.[ATIVO], SOURCE.[DATA_ADMISSAO], SOURCE.[DATA_SAIDA], SOURCE.[parameters_timestamp], SOURCE.[MATRICULA], SOURCE.[ID_TIPO_VENDA], SOURCE.[DESCRICAO_TIPO_VENDA], SOURCE.[CARGO]);";

            try
            {
                using (var conn = _conn.GetIDbConnection(databaseName))
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

        public async Task<bool> InsertParametersIfNotExists(string jobName, string parametersTableName, string databaseName)
        {
            try
            {
                var parameter = new
                {
                    method = jobName,
                    timestamp = @"<Parameter id=""timestamp"">[0]</Parameter>",
                    dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                <Parameter id=""data_upd_inicial"">[data_upd_inicial]</Parameter>
                                                <Parameter id=""data_upd_fim"">[data_upd_fim]</Parameter>",
                    individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                <Parameter id=""cod_vendedor"">[cod_vendedor]</Parameter>"
                };

                string? sql = $"IF NOT EXISTS (SELECT * FROM [linx_microvix].[{parametersTableName}] WHERE [method] = '{jobName}') " +
                              $"INSERT INTO [linx_microvix].[{parametersTableName}] ([method], [parameters_timestamp], [parameters_dateinterval], [parameters_individual]) " +
                               "VALUES (@method, @timestamp, @dateinterval, @individual)";


                using (var conn = _conn.GetIDbConnection(databaseName))
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
