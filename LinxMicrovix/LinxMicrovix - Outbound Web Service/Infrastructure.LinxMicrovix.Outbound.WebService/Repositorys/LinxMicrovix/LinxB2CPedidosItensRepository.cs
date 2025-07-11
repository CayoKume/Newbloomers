using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Entities.Exceptions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxB2CPedidosItensRepository : ILinxB2CPedidosItensRepository
    {
        private readonly ILinxMicrovixRepositoryBase<LinxB2CPedidosItens> _linxMicrovixRepositoryBase;

        public LinxB2CPedidosItensRepository(ILinxMicrovixRepositoryBase<LinxB2CPedidosItens> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxB2CPedidosItens> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxB2CPedidosItens());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].id_pedido_item, records[i].id_pedido, records[i].codigoproduto, records[i].quantidade, records[i].vl_unitario,
                    records[i].timestamp, records[i].portal);
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
                var list = new List<string?>();

                for (int i = 0; i <= indice; i++)
                {
                    string identificadores = String.Empty;
                    var top1000List = registros.Skip(i * 1000).Take(1000).ToList();

                    for (int j = 0; j < top1000List.Count(); j++)
                    {

                        if (j == top1000List.Count() - 1)
                            identificadores += $"{top1000List[j]}";
                        else
                            identificadores += $"{top1000List[j]}, ";
                    }

                    string sql = $"SELECT CONCAT('[', ID_PEDIDO_ITEM, ']', '|', '[', ID_PEDIDO, ']', '|', '[', CODIGOPRODUTO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxB2CPedidosItens] WHERE ID_PEDIDO_ITEM IN ({identificadores})";
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
                        identificadores += $"{registros[i]}";
                    else
                        identificadores += $"{registros[i]}, ";
                }

                string sql = $"SELECT CONCAT('[', ID_PEDIDO_ITEM, ']', '|', '[', ID_PEDIDO, ']', '|', '[', CODIGOPRODUTO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxB2CPedidosItens] WHERE ID_PEDIDO_ITEM IN ({identificadores})";
                var result = await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
                list.AddRange(result);

                return list;
            }
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxB2CPedidosItens? record)
        {
            string? sql = @$"INSERT INTO [untreated].[{jobParameter.tableName}]
                            ([lastupdateon], [id_pedido_item], [id_pedido], [codigoproduto], [quantidade], [vl_unitario], [timestamp], [portal])
                            Values
                            (@lastupdateon, @id_pedido_item, @id_pedido, @codigoproduto, @quantidade, @vl_unitario, @timestamp, @portal)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
