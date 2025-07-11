using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Entities.Exceptions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxClientesFornecRepository : ILinxClientesFornecRepository
    {
        private readonly ILinxMicrovixRepositoryBase<LinxClientesFornec> _linxMicrovixRepositoryBase;

        public LinxClientesFornecRepository(ILinxMicrovixRepositoryBase<LinxClientesFornec> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClientesFornec> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxClientesFornec());

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
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<string?> registros)
        {
            int indice = registros.Count() / 1000;

            if (indice > 1)
            {
                var list = new List<string>();

                for (int i = 0; i <= indice; i++)
                {
                    string identificadores = String.Empty;
                    var top1000List = registros.Skip(i * 1000).Take(1000).ToList();

                    for (int j = 0; j < top1000List.Count(); j++)
                    {

                        if (j == top1000List.Count() - 1)
                            identificadores += $"'{top1000List[j]}'";
                        else
                            identificadores += $"'{top1000List[j]}', ";
                    }

                    string sql = $"SELECT CONCAT('[', COD_CLIENTE, ']', '|', '[', DOC_CLIENTE, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxClientesFornec] WHERE DOC_CLIENTE IN ({identificadores})";
                    var result = await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
                    list.AddRange(result);
                }

                return list;
            }
            else
            {
                var list = new List<string>();
                string identificadores = String.Empty;

                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i]}'";
                    else
                        identificadores += $"'{registros[i]}', ";
                }

                string sql = $"SELECT CONCAT('[', COD_CLIENTE, ']', '|', '[', DOC_CLIENTE, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxClientesFornec] WHERE DOC_CLIENTE IN ({identificadores})";
                var result = await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
                list.AddRange(result);

                return list;
            }
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClientesFornec? record)
        {
            string? sql = @$"INSERT INTO [untreated].[{jobParameter.tableName}]
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

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
