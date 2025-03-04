using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxB2CPedidosStatusRepository : ILinxB2CPedidosStatusRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<LinxB2CPedidosStatus> _linxMicrovixRepositoryBase;

        public LinxB2CPedidosStatusRepository(ILinxMicrovixAzureSQLRepositoryBase<LinxB2CPedidosStatus> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxB2CPedidosStatus> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxB2CPedidosStatus());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id, records[i].id_status, records[i].id_pedido, records[i].data_hora, records[i].anotacao,
                        records[i].timestamp, records[i].portal);
                }

                _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
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

        public async Task<List<LinxB2CPedidosStatus>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxB2CPedidosStatus> registros)
        {
            try
            {
                int indice = registros.Count() / 1000;

                if (indice > 1)
                {
                    var list = new List<LinxB2CPedidosStatus>();
                    for (int i = 0; i <= indice; i++)
                    {
                        string identificadores = String.Empty;
                        var top1000List = registros.Skip(i * 1000).Take(1000).ToList();

                        for (int j = 0; j < top1000List.Count(); j++)
                        {

                            if (j == top1000List.Count() - 1)
                                identificadores += $"'{top1000List[j].id}'";
                            else
                                identificadores += $"'{top1000List[j].id}', ";
                        }

                        string sql = $"SELECT id, id_pedido, id_status, TIMESTAMP FROM [linx_microvix_erp].[LinxB2CPedidosStatus] WHERE id IN ({identificadores})";
                        var result = await _linxMicrovixRepositoryBase.GetRegistersExists(sql);
                        list.AddRange(result);
                    }

                    return list;
                }
                else
                {
                    var identificadores = String.Empty;
                    var list = new List<LinxB2CPedidosStatus>();

                    for (int i = 0; i < registros.Count(); i++)
                    {
                        if (i == registros.Count() - 1)
                            identificadores += $"'{registros[i].id}'";
                        else
                            identificadores += $"'{registros[i].id}', ";
                    }

                    string sql = $"SELECT id, id_pedido, id_status, TIMESTAMP FROM [linx_microvix_erp].[LinxB2CPedidosStatus] WHERE id IN ({identificadores})";
                    var result = await _linxMicrovixRepositoryBase.GetRegistersExists(sql);
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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxB2CPedidosStatus? record)
        {
            string? sql = @$"INSERT INTO [untreated].[{jobParameter.tableName}]
                            ([lastupdateon],[id],[id_status],[id_pedido],[data_hora],[anotacao],[timestamp],[portal])
                            Values
                            (@lastupdateon,@id,@id_status,@id_pedido,@data_hora,@anotacao,@timestamp,@portal)";

            try
            {
                return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
            }
            catch
            {
                throw;
            }
        }
    }
}
