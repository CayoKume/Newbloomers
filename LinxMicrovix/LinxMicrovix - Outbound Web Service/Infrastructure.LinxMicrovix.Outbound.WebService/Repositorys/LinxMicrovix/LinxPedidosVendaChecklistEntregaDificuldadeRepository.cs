using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxPedidosVendaChecklistEntregaDificuldadeRepository : ILinxPedidosVendaChecklistEntregaDificuldadeRepository
    {
        public LinxPedidosVendaChecklistEntregaDificuldadeRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPedidosVendaChecklistEntregaDificuldade> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxPedidosVendaChecklistEntregaDificuldade>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPedidosVendaChecklistEntregaDificuldade> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPedidosVendaChecklistEntregaDificuldade? record)
        {
            throw new NotImplementedException();
        }
    }
}
