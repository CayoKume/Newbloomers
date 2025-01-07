using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxPedidosVendaChecklistEntregaArmazenamentoRepository : ILinxPedidosVendaChecklistEntregaArmazenamentoRepository
    {
        public LinxPedidosVendaChecklistEntregaArmazenamentoRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPedidosVendaChecklistEntregaArmazenamento> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxPedidosVendaChecklistEntregaArmazenamento>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPedidosVendaChecklistEntregaArmazenamento> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPedidosVendaChecklistEntregaArmazenamento? record)
        {
            throw new NotImplementedException();
        }
    }
}
