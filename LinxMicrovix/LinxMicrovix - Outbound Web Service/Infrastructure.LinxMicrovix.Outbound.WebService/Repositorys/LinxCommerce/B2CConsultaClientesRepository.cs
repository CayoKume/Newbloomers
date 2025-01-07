using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaClientesRepository : IB2CConsultaClientesRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaClientes> _linxMicrovixRepositoryBase;

        public B2CConsultaClientesRepository(ILinxMicrovixRepositoryBase<B2CConsultaClientes> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaClientes> records)
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
                    stage: EnumStages.BulkInsertIntoTableRaw,
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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaClientes? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
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

        public async Task<List<B2CConsultaClientes>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaClientes> registros)
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

                string sql = $"SELECT DOC_CLIENTE, TIMESTAMP FROM B2CCONSULTACLIENTES WHERE DOC_CLIENTE IN ({identificadores})";

                return await _linxMicrovixRepositoryBase.GetRegistersExists(jobParameter, sql);
            }
            catch (Exception ex) when (ex is not InternalException && ex is not SQLCommandException)
            {
                throw new InternalException(
                    stage: EnumStages.GetRegistersExists,
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
