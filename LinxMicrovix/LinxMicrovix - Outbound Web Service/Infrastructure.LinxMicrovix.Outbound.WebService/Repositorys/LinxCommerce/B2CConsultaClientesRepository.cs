using Domain.IntegrationsCore.Exceptions;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;
using Domain.IntegrationsCore.Entities.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaClientesRepository : IB2CConsultaClientesRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaClientes> _linxMicrovixRepositoryBase;

        public B2CConsultaClientesRepository (ILinxMicrovixRepositoryBase<B2CConsultaClientes> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<B2CConsultaClientes> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaClientes());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].cod_cliente_b2c, records[i].cod_cliente_erp, records[i].doc_cliente, records[i].nm_cliente, records[i].nm_mae, records[i].nm_pai, records[i].nm_conjuge,
                        records[i].dt_cadastro, records[i].dt_nasc_cliente, records[i].end_cliente, records[i].complemento_end_cliente, records[i].nr_rua_cliente, records[i].bairro_cliente, records[i].cep_cliente,
                        records[i].cidade_cliente, records[i].uf_cliente, records[i].fone_cliente, records[i].fone_comercial, records[i].cel_cliente, records[i].email_cliente, records[i].rg_cliente, records[i].rg_orgao_emissor,
                        records[i].estado_civil_cliente, records[i].empresa_cliente, records[i].cargo_cliente, records[i].sexo_cliente, records[i].dt_update, records[i].ativo, records[i].receber_email, records[i].dt_expedicao_rg,
                        records[i].naturalidade, records[i].tempo_residencia, records[i].renda, records[i].numero_compl_rua_cliente, records[i].timestamp, records[i].tipo_pessoa, records[i].portal, records[i].aceita_programa_fidelidade);
                }

                _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                    jobParameter: jobParameter, 
                    dataTable: table, 
                    dataTableRowsNumber: table.Rows.Count
                );

                return true;
            }
            catch (Exception ex) when (ex is not InternalException && ex is not SQLCommandException)
            {
                throw new InternalException(
                    step: EnumSteps.BulkInsertIntoTableRaw,
                    error: EnumError.Exception,
                    level: EnumMessageLevel.Error,
                    message: "Error when filling system data table",
                    exceptionMessage: ex.Message
                );
            }
            catch
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
                                                  <Parameter id=""doc_cliente"">[doc_cliente]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaClientes? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [cod_cliente_b2c], [cod_cliente_erp], [doc_cliente], [nm_cliente], [nm_mae], [nm_pai], [nm_conjuge], [dt_cadastro], " +
                          "[dt_nasc_cliente], [end_cliente], [complemento_end_cliente], [nr_rua_cliente], [bairro_cliente], [cep_cliente], [cidade_cliente], " +
                          "[uf_cliente], [fone_cliente], [fone_comercial], [cel_cliente], [email_cliente], [rg_cliente], [rg_orgao_emissor], [estado_civil_cliente], " +
                          "[empresa_cliente], [cargo_cliente], [sexo_cliente], [dt_update], [ativo], [receber_email], [dt_expedicao_rg], [naturalidade], [tempo_residencia], " +
                          "[renda], [numero_compl_rua_cliente], [timestamp], [tipo_pessoa], [portal], [aceita_programa_fidelidade])" +
                          "Values " +
                          "(@lastupdateon, @cod_cliente_b2c, @cod_cliente_erp, @doc_cliente, @nm_cliente, @nm_mae, @nm_pai, @nm_conjuge, @dt_cadastro, " +
                          "@dt_nasc_cliente, @end_cliente, @complemento_end_cliente, @nr_rua_cliente, @bairro_cliente, @cep_cliente, @cidade_cliente, " +
                          "@uf_cliente, @fone_cliente, @fone_comercial, @cel_cliente, @email_cliente, @rg_cliente, @rg_orgao_emissor, @estado_civil_cliente, " +
                          "@empresa_cliente, @cargo_cliente, @sexo_cliente, @dt_update, @ativo, @receber_email, @dt_expedicao_rg, @naturalidade, @tempo_residencia, " +
                          "@renda, @numero_compl_rua_cliente, @timestamp, @tipo_pessoa, @portal, @aceita_programa_fidelidade)";

            try
            {
                return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter: jobParameter, sql: sql, record: record);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<B2CConsultaClientes>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<B2CConsultaClientes> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].doc_cliente}'";
                    else
                        identificadores += $"'{registros[i].doc_cliente}', ";
                }

                string sql = $"SELECT DOC_CLIENTE, TIMESTAMP FROM B2CCONSULTACLIENTES_TRUSTED WHERE DOC_CLIENTE IN ({identificadores})";

                return await _linxMicrovixRepositoryBase.GetRegistersExists(jobParameter, sql);
            }
            catch (Exception ex) when (ex is not InternalException && ex is not SQLCommandException)
            {
                throw new InternalException(
                    step: EnumSteps.GetRegistersExists,
                    error: EnumError.Exception,
                    level: EnumMessageLevel.Error,
                    message: "Error when filling identifiers to sql command",
                    exceptionMessage: ex.Message
                );
            }
            catch
            {
                throw;
            }
        }
    }
}
