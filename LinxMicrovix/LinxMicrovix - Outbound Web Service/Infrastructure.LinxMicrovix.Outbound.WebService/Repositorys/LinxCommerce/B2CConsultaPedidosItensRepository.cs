using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;
using System.Collections.Generic;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaPedidosItensRepository : IB2CConsultaPedidosItensRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaPedidosItens> _linxMicrovixRepositoryBase;

        public B2CConsultaPedidosItensRepository(ILinxMicrovixRepositoryBase<B2CConsultaPedidosItens> linxMicrovixRepositoryBase) =>
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaPedidosItens> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaPedidosItens());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_pedido_item, records[i].id_pedido, records[i].codigoproduto, records[i].quantidade, records[i].vl_unitario, records[i].timestamp, records[i].portal);
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

        public async Task<List<B2CConsultaPedidosItens>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaPedidosItens> registros)
        {
            try
            {
                int indice = registros.Count() / 1000;

                if (indice > 1)
                {
                    var list = new List<B2CConsultaPedidosItens>();

                    for (int i = 0; i <= indice; i++)
                    {
                        string identificadores = String.Empty;
                        var top1000List = registros.Skip(i * 1000).Take(1000).ToList();

                        for (int j = 0; j < top1000List.Count(); j++)
                        {

                            if (j == top1000List.Count() - 1)
                                identificadores += $"'{top1000List[j].id_pedido_item}'";
                            else
                                identificadores += $"'{top1000List[j].id_pedido_item}', ";
                        }

                        string sql = $"SELECT ID_PEDIDO_ITEM, ID_PEDIDO, CODIGOPRODUTO FROM [linx_microvix_commerce].[B2CCONSULTAPEDIDOSITENS] WHERE ID_PEDIDO_ITEM IN ({identificadores})";
                        var result = await _linxMicrovixRepositoryBase.GetRegistersExists(jobParameter, sql);
                        list.AddRange(result);
                    }

                    return list;
                }
                else
                {
                    var list = new List<B2CConsultaPedidosItens>();
                    string identificadores = String.Empty;

                    for (int i = 0; i < registros.Count(); i++)
                    {

                        if (i == registros.Count() - 1)
                            identificadores += $"'{registros[i].id_pedido_item}'";
                        else
                            identificadores += $"'{registros[i].id_pedido_item}', ";
                    }

                    string sql = $"SELECT ID_PEDIDO_ITEM, ID_PEDIDO, CODIGOPRODUTO FROM [linx_microvix_commerce].[B2CCONSULTAPEDIDOSITENS] WHERE ID_PEDIDO_ITEM IN ({identificadores})";
                    var result = await _linxMicrovixRepositoryBase.GetRegistersExists(jobParameter, sql);
                    list.AddRange(result);

                    return list;
                }
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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaPedidosItens? record)
        {
            string? sql = $"INSERT INTO [untreated].{jobParameter.tableName} " +
                          "([lastupdateon], [id_pedido_item], [id_pedido], [codigoproduto], [quantidade], [vl_unitario], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @id_pedido_item, @id_pedido, @codigoproduto, @quantidade, @vl_unitario, @timestamp, @portal)";

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
