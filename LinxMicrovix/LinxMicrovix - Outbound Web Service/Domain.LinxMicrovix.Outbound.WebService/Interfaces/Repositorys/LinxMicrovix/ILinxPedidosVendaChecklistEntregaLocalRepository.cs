using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxPedidosVendaChecklistEntregaLocalRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPedidosVendaChecklistEntregaLocal? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPedidosVendaChecklistEntregaLocal> records);
        public Task<List<LinxPedidosVendaChecklistEntregaLocal>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPedidosVendaChecklistEntregaLocal> registros);
    }
}
