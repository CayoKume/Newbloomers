using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxB2CPedidosStatusRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, LinxB2CPedidosStatus? record);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<LinxB2CPedidosStatus> records);
        public Task<List<LinxB2CPedidosStatus>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<LinxB2CPedidosStatus> registros);
    }
}
