using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaClientesEnderecosEntregaRepository : IB2CConsultaClientesEnderecosEntregaRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaClientesEnderecosEntrega> _linxMicrovixRepositoryBase;

        public B2CConsultaClientesEnderecosEntregaRepository(ILinxMicrovixRepositoryBase<B2CConsultaClientesEnderecosEntrega> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaClientesEnderecosEntrega> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaClientesEnderecosEntrega());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].id_endereco_entrega, records[i].cod_cliente_erp, records[i].cod_cliente_b2c, records[i].endereco_cliente, records[i].numero_rua_cliente, records[i].complemento_end_cli,
                    records[i].cep_cliente, records[i].bairro_cliente, records[i].cidade_cliente, records[i].uf_cliente, records[i].descricao, records[i].principal, records[i].id_cidade, records[i].timestamp, records[i].portal);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<int?> registros)
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

                    string sql = $"SELECT CONCAT('[', ID_ENDERECO_ENTREGA, ']', '|', '[', COD_CLIENTE_B2C, ']', '|', '[', [TIMESTAMP], ']') FROM linx_microvix_commerce.B2CCONSULTACLIENTESENDERECOSENTREGA WHERE ID_ENDERECO_ENTREGA IN ({identificadores})";
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

                string sql = $"SELECT CONCAT('[', ID_ENDERECO_ENTREGA, ']', '|', '[', COD_CLIENTE_B2C, ']', '|', '[', [TIMESTAMP], ']') FROM linx_microvix_commerce.B2CCONSULTACLIENTESENDERECOSENTREGA WHERE ID_ENDERECO_ENTREGA IN ({identificadores})";
                var result = await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
                list.AddRange(result);

                return list;
            }
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaClientesEnderecosEntrega? record)
        {
            string? sql = $"INSERT INTO ([LASTUPDATEON], [ID_ENDERECO_ENTREGA], [COD_CLIENTE_ERP], [COD_CLIENTE_B2C], [ENDRECO_CLIENTE], [NUMERO_RUA_CLIENTE], [COMPLEMENTO_END_CLI], [CEP_CLIENTE], [BAIRRO_CLIENTE], " +
                          "[CIDADE_CLIENTE], [UF_CLIENTE], [DESCRICAO], [PRINCIPAL], [ID_CIDADE], [TIMESTAMP], [PORTAL]) " +
                          "VALUES " +
                          "(@lastupdateon, @id_endereco_entrega, @cod_cliente_erp, @cod_cliente_b2c, @endereco_cliente, @numero_rua_cliente, @complemento_end_cli, @cep_cliente, " +
                          "@bairro_cliente, @cidade_cliente, @uf_cliente, @descricao, @principal, @id_cidade, @timestamp, @portal)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
