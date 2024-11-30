using Dapper;
using DatabaseInit.Domain.Interfaces.LinxCommerce;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repository.LinxCommerce
{
    public class B2CConsultaClientesEnderecosEntregaRepository : IB2CConsultaClientesEnderecosEntregaRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaClientesEnderecosEntregaRepository(ISQLServerConnection? conn) =>
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
                        conn.CreateTable<B2CConsultaClientesEnderecosEntrega>(tableName: $"{jobParameter.jobName}_raw");
                        conn.CreateTable<B2CConsultaClientesEnderecosEntrega>(tableName: $"{jobParameter.jobName}_trusted");

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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTACLIENTESENDERECOSENTREGA_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTACLIENTESENDERECOSENTREGA_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTACLIENTESENDERECOSENTREGA_TRUSTED] AS TARGET
		                           USING [B2CCONSULTACLIENTESENDERECOSENTREGA_RAW] AS SOURCE

		                           ON (
			                           TARGET.ID_ENDERECO_ENTREGA = SOURCE.ID_ENDERECO_ENTREGA
		                           )		                           WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_ENDERECO_ENTREGA] = SOURCE.[ID_ENDERECO_ENTREGA],
			                           TARGET.[COD_CLIENTE_ERP] = SOURCE.[COD_CLIENTE_ERP],
			                           TARGET.[COD_CLIENTE_B2C] = SOURCE.[COD_CLIENTE_B2C],
			                           TARGET.[ENDERECO_CLIENTE] = SOURCE.[ENDERECO_CLIENTE],
			                           TARGET.[NUMERO_RUA_CLIENTE] = SOURCE.[NUMERO_RUA_CLIENTE],
			                           TARGET.[COMPLEMENTO_END_CLI] = SOURCE.[COMPLEMENTO_END_CLI],
			                           TARGET.[CEP_CLIENTE] = SOURCE.[CEP_CLIENTE],
			                           TARGET.[BAIRRO_CLIENTE] = SOURCE.[BAIRRO_CLIENTE],
			                           TARGET.[CIDADE_CLIENTE] = SOURCE.[CIDADE_CLIENTE],
			                           TARGET.[UF_CLIENTE] = SOURCE.[UF_CLIENTE],
			                           TARGET.[DESCRICAO] = SOURCE.[DESCRICAO],
			                           TARGET.[PRINCIPAL] = SOURCE.[PRINCIPAL],
			                           TARGET.[ID_CIDADE] = SOURCE.[ID_CIDADE],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

		                           WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_ENDERECO_ENTREGA] NOT IN (SELECT [ID_ENDERECO_ENTREGA] FROM [B2CCONSULTACLIENTESENDERECOSENTREGA_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_ENDERECO_ENTREGA], [COD_CLIENTE_ERP], [COD_CLIENTE_B2C], [ENDERECO_CLIENTE], [NUMERO_RUA_CLIENTE], [COMPLEMENTO_END_CLI], [CEP_CLIENTE], [BAIRRO_CLIENTE], [CIDADE_CLIENTE],
			                           [UF_CLIENTE], [DESCRICAO], [PRINCIPAL], [ID_CIDADE], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_ENDERECO_ENTREGA], SOURCE.[COD_CLIENTE_ERP], SOURCE.[COD_CLIENTE_B2C], SOURCE.[ENDERECO_CLIENTE], SOURCE.[NUMERO_RUA_CLIENTE], SOURCE.[COMPLEMENTO_END_CLI], SOURCE.[CEP_CLIENTE],
			                           SOURCE.[BAIRRO_CLIENTE], SOURCE.[CIDADE_CLIENTE], SOURCE.[UF_CLIENTE], SOURCE.[DESCRICAO], SOURCE.[PRINCIPAL], SOURCE.[ID_CIDADE], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
	                           END'
                           )
                           END"

;

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
                    parameters_individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                <Parameter id=""cod_cliente_b2c"">[cod_cliente_b2c]</Parameter>",
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
