using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxPedidosVendaChecklistEntregaLocalRepository : ILinxPedidosVendaChecklistEntregaLocalRepository
    {
        public LinxPedidosVendaChecklistEntregaLocalRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPedidosVendaChecklistEntregaLocal> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxPedidosVendaChecklistEntregaLocal>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPedidosVendaChecklistEntregaLocal> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPedidosVendaChecklistEntregaLocal? record)
        {
            throw new NotImplementedException();
        }
    }
}
