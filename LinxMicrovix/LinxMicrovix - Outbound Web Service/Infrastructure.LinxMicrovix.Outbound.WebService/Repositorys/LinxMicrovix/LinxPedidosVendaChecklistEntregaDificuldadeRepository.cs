using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxPedidosVendaChecklistEntregaDificuldade>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPedidosVendaChecklistEntregaDificuldade> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPedidosVendaChecklistEntregaDificuldade? record)
        {
            throw new NotImplementedException();
        }
    }
}
