using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxB2CPedidosRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxB2CPedidos? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxB2CPedidos> records);
        public Task<List<LinxB2CPedidos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxB2CPedidos> registros);
    }
}
