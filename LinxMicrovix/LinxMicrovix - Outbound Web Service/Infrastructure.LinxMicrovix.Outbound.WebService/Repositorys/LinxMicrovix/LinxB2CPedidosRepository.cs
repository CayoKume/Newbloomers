using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxB2CPedidosRepository : ILinxB2CPedidosRepository
    {
        public LinxB2CPedidosRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxB2CPedidos> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxB2CPedidos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxB2CPedidos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxB2CPedidos? record)
        {
            throw new NotImplementedException();
        }
    }
}
