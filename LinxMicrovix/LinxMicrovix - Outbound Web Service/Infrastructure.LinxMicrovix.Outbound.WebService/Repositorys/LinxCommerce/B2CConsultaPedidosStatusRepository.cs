using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaPedidosStatusRepository : IB2CConsultaPedidosStatusRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaPedidosStatus> _linxMicrovixRepositoryBase;

        public B2CConsultaPedidosStatusRepository(ILinxMicrovixRepositoryBase<B2CConsultaPedidosStatus> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaPedidosStatus> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaPedidosStatus());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].id, records[i].id_status, records[i].id_pedido, records[i].data_hora, records[i].anotacao, records[i].timestamp, records[i].portal);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<Int32?> registros)
        {
            var identificadores = String.Empty;
            for (int i = 0; i < registros.Count(); i++)
            {
                if (i == registros.Count() - 1)
                    identificadores += $"{registros[i]}";
                else
                    identificadores += $"{registros[i]}, ";
            }

            string sql = $"SELECT CONCAT('[', ID, ']', '|', '[', ID_STATUS, ']', '|', '[', ID_PEDIDO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CConsultaPedidosStatus] WHERE ID IN ({identificadores})";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaPedidosStatus? record)
        {
            string? sql = $"INSERT INTO [untreated].{jobParameter.tableName} " +
                          "([lastupdateon], [id], [id_status], [id_pedido], [data_hora], [anotacao], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @id, @id_status, @id_pedido, @data_hora, @anotacao, @timestamp, @portal)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
