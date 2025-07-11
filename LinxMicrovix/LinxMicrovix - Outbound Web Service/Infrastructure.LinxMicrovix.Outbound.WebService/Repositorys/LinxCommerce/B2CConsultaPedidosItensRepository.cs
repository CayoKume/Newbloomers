using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaPedidosItensRepository : IB2CConsultaPedidosItensRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaPedidosItens> _linxMicrovixRepositoryBase;

        public B2CConsultaPedidosItensRepository(ILinxMicrovixRepositoryBase<B2CConsultaPedidosItens> linxMicrovixRepositoryBase) =>
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaPedidosItens> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaPedidosItens());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].id_pedido_item, records[i].id_pedido, records[i].codigoproduto, records[i].quantidade, records[i].vl_unitario, records[i].timestamp, records[i].portal);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<Int64?> registros)
        {
            int indice = registros.Count() / 1000;

            if (indice > 1)
            {
                var list = new List<string?>();

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

                    string sql = $"SELECT CONCAT('[', ID_PEDIDO_ITEM, ']', '|', '[', ID_PEDIDO, ']', '|', '[', CODIGOPRODUTO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPEDIDOSITENS] WHERE ID_PEDIDO_ITEM IN ({identificadores})";
                    var result = await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
                    list.AddRange(result);
                }

                return list;
            }
            else
            {
                var list = new List<string?>();
                string identificadores = String.Empty;

                for (int i = 0; i < registros.Count(); i++)
                {

                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i]}'";
                    else
                        identificadores += $"'{registros[i]}', ";
                }

                string sql = $"SELECT CONCAT('[', ID_PEDIDO_ITEM, ']', '|', '[', ID_PEDIDO, ']', '|', '[', CODIGOPRODUTO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPEDIDOSITENS] WHERE ID_PEDIDO_ITEM IN ({identificadores})";
                var result = await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
                list.AddRange(result);

                return list;
            }
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaPedidosItens? record)
        {
            string? sql = $"INSERT INTO [untreated].{jobParameter.tableName} " +
                          "([lastupdateon], [id_pedido_item], [id_pedido], [codigoproduto], [quantidade], [vl_unitario], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @id_pedido_item, @id_pedido, @codigoproduto, @quantidade, @vl_unitario, @timestamp, @portal)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
