using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxClientesFornecRepository : ILinxClientesFornecRepository
    {
        private readonly ILinxMicrovixRepositoryBase<LinxClientesFornec> _linxMicrovixRepositoryBase;

        public LinxClientesFornecRepository(ILinxMicrovixRepositoryBase<LinxClientesFornec> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClientesFornec> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new LinxClientesFornec());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].cod_cliente, records[i].razao_cliente, records[i].nome_cliente, records[i].doc_cliente,
                        records[i].tipo_cliente, records[i].endereco_cliente, records[i].numero_rua_cliente, records[i].complement_end_cli, records[i].bairro_cliente, records[i].cep_cliente,
                        records[i].cidade_cliente, records[i].uf_cliente, records[i].pais, records[i].fone_cliente, records[i].email_cliente, records[i].sexo, records[i].data_cadastro,
                        records[i].data_nascimento, records[i].cel_cliente, records[i].ativo, records[i].dt_update, records[i].inscricao_estadual, records[i].incricao_municipal, records[i].identidade_cliente, 
                        records[i].cartao_fidelidade, records[i].cod_ibge_municipio, records[i].classe_cliente, records[i].matricula_conveniado, records[i].tipo_cadastro, records[i].empresa_cadastro, records[i].id_estado_civil, 
                        records[i].fax_cliente, records[i].site_cliente, records[i].timestamp, records[i].cliente_anonimo, records[i].limite_compras, records[i].codigo_ws, records[i].limite_credito_compra, records[i].id_classe_fiscal, 
                        records[i].obs, records[i].mae);
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

        public async Task<List<LinxClientesFornec>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClientesFornec> registros)
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

                string sql = $"SELECT cod_cliente, DOC_CLIENTE, TIMESTAMP FROM [linx_microvix_erp].[LinxClientesFornec] WHERE DOC_CLIENTE IN ({identificadores})";

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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClientesFornec? record)
        {
            string? sql = @$"INSERT INTO {jobParameter.tableName} 
                            ([lastupdateon],[portal],[cod_cliente],[razao_cliente],[nome_cliente],[doc_cliente],[tipo_cliente],[endereco_cliente],[numero_rua_cliente],[complement_end_cli],
                             [bairro_cliente],[cep_cliente],[cidade_cliente],[uf_cliente],[pais],[fone_cliente],[email_cliente],[sexo],[data_cadastro],[data_nascimento],[cel_cliente],[ativo],
                             [dt_update],[inscricao_estadual],[incricao_municipal],[identidade_cliente],[cartao_fidelidade],[cod_ibge_municipio],[classe_cliente],[matricula_conveniado],[tipo_cadastro],
                             [empresa_cadastro],[id_estado_civil],[fax_cliente],[site_cliente],[timestamp],[cliente_anonimo],[limite_compras],[codigo_ws],[limite_credito_compra],[id_classe_fiscal],[obs],
                             [mae])
                            Values
                            (@lastupdateon,@portal,@cod_cliente,@razao_cliente,@nome_cliente,@doc_cliente,@tipo_cliente,@endereco_cliente,@numero_rua_cliente,@complement_end_cli,@bairro_cliente,@cep_cliente,
                             @cidade_cliente,@uf_cliente,@pais,@fone_cliente,@email_cliente,@sexo,@data_cadastro,@data_nascimento,@cel_cliente,@ativo,@dt_update,@inscricao_estadual,@incricao_municipal,
                             @identidade_cliente,@cartao_fidelidade,@cod_ibge_municipio,@classe_cliente,@matricula_conveniado,@tipo_cadastro,@empresa_cadastro,@id_estado_civil,@fax_cliente,@site_cliente,
                             @timestamp,@cliente_anonimo,@limite_compras,@codigo_ws,@limite_credito_compra,@id_classe_fiscal,@obs,@mae)";

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
