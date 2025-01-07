using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxPedidosVendaRepository : ILinxPedidosVendaRepository
    {
        public LinxPedidosVendaRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPedidosVenda> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxPedidosVenda>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPedidosVenda> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPedidosVenda? record)
        {
            throw new NotImplementedException();
        }
    }
}
