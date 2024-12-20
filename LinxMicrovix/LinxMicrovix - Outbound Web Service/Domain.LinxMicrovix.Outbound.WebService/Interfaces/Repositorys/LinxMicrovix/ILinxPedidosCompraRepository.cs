using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxPedidosCompraRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPedidosCompra? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPedidosCompra> records);
        public Task<List<LinxPedidosCompra>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPedidosCompra> registros);
    }
}
