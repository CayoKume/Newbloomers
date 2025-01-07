using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxB2CPedidosStatusRepository : ILinxB2CPedidosStatusRepository
    {
        public LinxB2CPedidosStatusRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxB2CPedidosStatus> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxB2CPedidosStatus>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxB2CPedidosStatus> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxB2CPedidosStatus? record)
        {
            throw new NotImplementedException();
        }
    }
}
