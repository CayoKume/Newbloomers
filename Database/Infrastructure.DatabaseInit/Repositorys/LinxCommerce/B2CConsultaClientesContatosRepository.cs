using Dapper;
using Domain.DatabaseInit.Interfaces.LinxCommerce;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using System.Reflection.Metadata;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxCommerce
{
    public class B2CConsultaClientesContatosRepository : IB2CConsultaClientesContatosRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaClientesContatosRepository(ISQLServerConnection? conn) =>
            (_conn) = (conn);

        public async Task<bool> CreateDataTableIfNotExists(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = @$"SELECT DISTINCT * FROM [INFORMATION_SCHEMA].[TABLES] (NOLOCK) WHERE TABLE_NAME LIKE '%{jobParameter.jobName}%'";

            try
            {
                using (var conn = _conn.GetIDbConnection(jobParameter.databaseName))
                {
                    var result = await conn.QueryAsync(sql: sql);

                    if (result.Count() == 0)
                    {
                        conn.CreateTable<B2CConsultaClientesContatos>(tableName: $"{jobParameter.jobName}_raw");
                        conn.CreateTable<B2CConsultaClientesContatos>(tableName: $"{jobParameter.jobName}_trusted");

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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTACLIENTESCONTATOS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTACLIENTESCONTATOS_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTACLIENTESCONTATOS_TRUSTED] AS TARGET
                                   USING [B2CCONSULTACLIENTESCONTATOS_RAW] AS SOURCE

                                   ON (
			                           TARGET.ID_CLIENTES_CONTATOS = SOURCE.ID_CLIENTES_CONTATOS
		                           )
        
		                           WHEN MATCHED AND SOURCE.[TIMESTAMP] != TARGET.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_CLIENTES_CONTATOS] = SOURCE.[ID_CLIENTES_CONTATOS],
			                           TARGET.[ID_CONTATO_B2C] = SOURCE.[ID_CONTATO_B2C],
			                           TARGET.[NOME_CONTATO] = SOURCE.[NOME_CONTATO],
			                           TARGET.[DATA_NASC_CONTATO] = SOURCE.[DATA_NASC_CONTATO],
			                           TARGET.[SEXO_CONTATO] = SOURCE.[SEXO_CONTATO],
			                           TARGET.[ID_PARENTESCO] = SOURCE.[ID_PARENTESCO],
			                           TARGET.[FONE_CONTATO] = SOURCE.[FONE_CONTATO],
			                           TARGET.[CELULAR_CONTATO] = SOURCE.[CELULAR_CONTATO],
			                           TARGET.[EMAIL_CONTATO] = SOURCE.[EMAIL_CONTATO],
			                           TARGET.[COD_CLIENTE_ERP] = SOURCE.[COD_CLIENTE_ERP],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_CLIENTES_CONTATOS] NOT IN (SELECT [ID_CLIENTES_CONTATOS] FROM [B2CCONSULTACLIENTESCONTATOS_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_CLIENTES_CONTATOS], [ID_CONTATO_B2C], [NOME_CONTATO], [DATA_NASC_CONTATO], [SEXO_CONTATO],
			                           [ID_PARENTESCO], [FONE_CONTATO], [CELULAR_CONTATO], [EMAIL_CONTATO], [COD_CLIENTE_ERP], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_CLIENTES_CONTATOS], SOURCE.[ID_CONTATO_B2C], SOURCE.[NOME_CONTATO], SOURCE.[DATA_NASC_CONTATO], SOURCE.[SEXO_CONTATO],
			                           SOURCE.[ID_PARENTESCO], SOURCE.[FONE_CONTATO], SOURCE.[CELULAR_CONTATO], SOURCE.[EMAIL_CONTATO], SOURCE.[COD_CLIENTE_ERP], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
	                           END'
                           )
                           END";

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
                    parameters_dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>",
                    parameters_individual = @"<Parameter id=""timestamp"">[0]</Parameter>",
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
