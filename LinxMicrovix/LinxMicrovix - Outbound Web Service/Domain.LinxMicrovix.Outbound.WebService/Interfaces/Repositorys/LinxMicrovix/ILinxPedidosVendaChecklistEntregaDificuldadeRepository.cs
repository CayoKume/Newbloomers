using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxPedidosVendaChecklistEntregaDificuldadeRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPedidosVendaChecklistEntregaDificuldade? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPedidosVendaChecklistEntregaDificuldade> records);
        public Task<List<LinxPedidosVendaChecklistEntregaDificuldade>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPedidosVendaChecklistEntregaDificuldade> registros);
    }
}
