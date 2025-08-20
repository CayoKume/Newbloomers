using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxPedidosVendaChecklistEntregaArmazenamento>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPedidosVendaChecklistEntregaArmazenamento> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPedidosVendaChecklistEntregaArmazenamento? record)
        {
            throw new NotImplementedException();
        }
    }
}
