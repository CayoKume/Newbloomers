using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxB2CPedidosStatusRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxB2CPedidosStatus? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxB2CPedidosStatus> records);
        public Task<List<LinxB2CPedidosStatus>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxB2CPedidosStatus> registros);
    }
}
