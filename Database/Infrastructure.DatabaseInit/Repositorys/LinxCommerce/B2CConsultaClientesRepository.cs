using Dapper;
using Domain.DatabaseInit.Interfaces.LinxCommerce;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using System.Reflection.Metadata;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxCommerce
{
    public class B2CConsultaClientesRepository : IB2CConsultaClientesRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaClientesRepository(ISQLServerConnection? conn) =>
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
                        conn.CreateTable<B2CConsultaClientes>(tableName: $"{jobParameter.jobName}_raw");
                        conn.CreateTable<B2CConsultaClientes>(tableName: $"{jobParameter.jobName}_trusted");

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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTACLIENTES_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTACLIENTES_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTACLIENTES_TRUSTED] AS TARGET
		                           USING [B2CCONSULTACLIENTES_RAW] AS SOURCE

		                           ON (
			                           TARGET.[COD_CLIENTE_B2C] = SOURCE.[COD_CLIENTE_B2C] AND
			                           TARGET.[COD_CLIENTE_ERP] = SOURCE.[COD_CLIENTE_ERP] AND
			                           TARGET.[DOC_CLIENTE]	 = SOURCE.[DOC_CLIENTE]
		                           )

		                           WHEN MATCHED AND SOURCE.[TIMESTAMP] != TARGET.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[COD_CLIENTE_B2C] = SOURCE.[COD_CLIENTE_B2C],
			                           TARGET.[COD_CLIENTE_ERP] = SOURCE.[COD_CLIENTE_ERP],
			                           TARGET.[DOC_CLIENTE] = SOURCE.[DOC_CLIENTE],
			                           TARGET.[NM_CLIENTE] = SOURCE.[NM_CLIENTE],
			                           TARGET.[NM_MAE] = SOURCE.[NM_MAE],
			                           TARGET.[NM_PAI] = SOURCE.[NM_PAI],
			                           TARGET.[NM_CONJUGE] = SOURCE.[NM_CONJUGE],
			                           TARGET.[DT_CADASTRO] = SOURCE.[DT_CADASTRO],
			                           TARGET.[DT_NASC_CLIENTE] = SOURCE.[DT_NASC_CLIENTE],
			                           TARGET.[END_CLIENTE] = SOURCE.[END_CLIENTE],
			                           TARGET.[COMPLEMENTO_END_CLIENTE] = SOURCE.[COMPLEMENTO_END_CLIENTE],
			                           TARGET.[NR_RUA_CLIENTE] = SOURCE.[NR_RUA_CLIENTE],
			                           TARGET.[BAIRRO_CLIENTE] = SOURCE.[BAIRRO_CLIENTE],
			                           TARGET.[CEP_CLIENTE] = SOURCE.[CEP_CLIENTE],
			                           TARGET.[CIDADE_CLIENTE] = SOURCE.[CIDADE_CLIENTE],
			                           TARGET.[UF_CLIENTE] = SOURCE.[UF_CLIENTE],
			                           TARGET.[FONE_CLIENTE] = SOURCE.[FONE_CLIENTE],
			                           TARGET.[FONE_COMERCIAL] = SOURCE.[FONE_COMERCIAL],
			                           TARGET.[CEL_CLIENTE] = SOURCE.[CEL_CLIENTE],
			                           TARGET.[EMAIL_CLIENTE] = SOURCE.[EMAIL_CLIENTE],
			                           TARGET.[RG_CLIENTE] = SOURCE.[RG_CLIENTE],
			                           TARGET.[RG_ORGAO_EMISSOR] = SOURCE.[RG_ORGAO_EMISSOR],
			                           TARGET.[ESTADO_CIVIL_CLIENTE] = SOURCE.[ESTADO_CIVIL_CLIENTE],
			                           TARGET.[EMPRESA_CLIENTE] = SOURCE.[EMPRESA_CLIENTE],
			                           TARGET.[CARGO_CLIENTE] = SOURCE.[CARGO_CLIENTE],
			                           TARGET.[SEXO_CLIENTE] = SOURCE.[SEXO_CLIENTE],
			                           TARGET.[DT_UPDATE] = SOURCE.[DT_UPDATE],
			                           TARGET.[ATIVO] = SOURCE.[ATIVO],
			                           TARGET.[RECEBER_EMAIL] = SOURCE.[RECEBER_EMAIL],
			                           TARGET.[DT_EXPEDICAO_RG] = SOURCE.[DT_EXPEDICAO_RG],
			                           TARGET.[NATURALIDADE] = SOURCE.[NATURALIDADE],
			                           TARGET.[TEMPO_RESIDENCIA] = SOURCE.[TEMPO_RESIDENCIA],
			                           TARGET.[RENDA] = SOURCE.[RENDA],
			                           TARGET.[NUMERO_COMPL_RUA_CLIENTE] = SOURCE.[NUMERO_COMPL_RUA_CLIENTE],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[TIPO_PESSOA] = SOURCE.[TIPO_PESSOA],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL],
			                           TARGET.[ACEITA_PROGRAMA_FIDELIDADE] = SOURCE.[ACEITA_PROGRAMA_FIDELIDADE]
	
		                           WHEN NOT MATCHED BY TARGET AND SOURCE.[DOC_CLIENTE] NOT IN (SELECT [DOC_CLIENTE] FROM [B2CCONSULTACLIENTES_TRUSTED]) THEN 
			                           INSERT 
			                           ([LASTUPDATEON], [COD_CLIENTE_B2C], [COD_CLIENTE_ERP], [DOC_CLIENTE], [NM_CLIENTE], [NM_MAE], [NM_PAI], [NM_CONJUGE], [DT_CADASTRO], [DT_NASC_CLIENTE], [END_CLIENTE],
			                           [COMPLEMENTO_END_CLIENTE], [NR_RUA_CLIENTE], [BAIRRO_CLIENTE], [CEP_CLIENTE], [CIDADE_CLIENTE], [UF_CLIENTE], [FONE_CLIENTE], [FONE_COMERCIAL], [CEL_CLIENTE], [EMAIL_CLIENTE], 
			                           [RG_CLIENTE], [RG_ORGAO_EMISSOR], [ESTADO_CIVIL_CLIENTE], [EMPRESA_CLIENTE], [CARGO_CLIENTE], [SEXO_CLIENTE], [DT_UPDATE], [ATIVO], [RECEBER_EMAIL], [DT_EXPEDICAO_RG], 
			                           [NATURALIDADE], [TEMPO_RESIDENCIA], [RENDA], [NUMERO_COMPL_RUA_CLIENTE], [TIMESTAMP], [TIPO_PESSOA], [PORTAL], [ACEITA_PROGRAMA_FIDELIDADE])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[COD_CLIENTE_B2C], SOURCE.[COD_CLIENTE_ERP], SOURCE.[DOC_CLIENTE], SOURCE.[NM_CLIENTE], SOURCE.[NM_MAE], SOURCE.[NM_PAI], SOURCE.[NM_CONJUGE], 
			                           SOURCE.[DT_CADASTRO], SOURCE.[DT_NASC_CLIENTE], SOURCE.[END_CLIENTE], SOURCE.[COMPLEMENTO_END_CLIENTE], SOURCE.[NR_RUA_CLIENTE], SOURCE.[BAIRRO_CLIENTE], 
			                           SOURCE.[CEP_CLIENTE], SOURCE.[CIDADE_CLIENTE], SOURCE.[UF_CLIENTE], SOURCE.[FONE_CLIENTE], SOURCE.[FONE_COMERCIAL], SOURCE.[CEL_CLIENTE], SOURCE.[EMAIL_CLIENTE], 
			                           SOURCE.[RG_CLIENTE], SOURCE.[RG_ORGAO_EMISSOR], SOURCE.[ESTADO_CIVIL_CLIENTE], SOURCE.[EMPRESA_CLIENTE], SOURCE.[CARGO_CLIENTE], SOURCE.[SEXO_CLIENTE], SOURCE.[DT_UPDATE], 
			                           SOURCE.[ATIVO], SOURCE.[RECEBER_EMAIL], SOURCE.[DT_EXPEDICAO_RG], SOURCE.[NATURALIDADE], SOURCE.[TEMPO_RESIDENCIA], SOURCE.[RENDA], SOURCE.[NUMERO_COMPL_RUA_CLIENTE], SOURCE.[TIMESTAMP], 
			                           SOURCE.[TIPO_PESSOA], SOURCE.[PORTAL], SOURCE.[ACEITA_PROGRAMA_FIDELIDADE]);
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
                    timestamp = @"<Parameter id=""timestamp"">[0]</Parameter>",
                    dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>",
                    individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                <Parameter id=""doc_cliente"">[doc_cliente]</Parameter>",
                    ativo = 1
                };

                string? sql = $"IF NOT EXISTS (SELECT * FROM [{jobParameter.parametersTableName}] WHERE [method] = '{jobParameter.jobName}') " +
                              $"INSERT INTO [{jobParameter.parametersTableName}] ([method], [timestamp], [dateinterval], [individual], [ativo]) " +
                               "VALUES (@method, @timestamp, @dateinterval, @individual, @ativo)";


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
