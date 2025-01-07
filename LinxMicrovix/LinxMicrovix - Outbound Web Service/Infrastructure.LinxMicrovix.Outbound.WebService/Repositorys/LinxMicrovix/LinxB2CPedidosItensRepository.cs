using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxB2CPedidosItensRepository : ILinxB2CPedidosItensRepository
    {
        public LinxB2CPedidosItensRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxB2CPedidosItens> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxB2CPedidosItens>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxB2CPedidosItens> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxB2CPedidosItens? record)
        {
            throw new NotImplementedException();
        }
    }
}
