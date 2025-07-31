using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxPedidosCompraRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPedidosCompra? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPedidosCompra> records);
        public Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<int?> registros);
    }
}
