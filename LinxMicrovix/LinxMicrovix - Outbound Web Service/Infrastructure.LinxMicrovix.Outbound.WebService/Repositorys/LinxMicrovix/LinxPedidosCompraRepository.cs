using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxPedidosCompraRepository : ILinxPedidosCompraRepository
    {
        public LinxPedidosCompraRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPedidosCompra> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxPedidosCompra>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPedidosCompra> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPedidosCompra? record)
        {
            throw new NotImplementedException();
        }
    }
}
