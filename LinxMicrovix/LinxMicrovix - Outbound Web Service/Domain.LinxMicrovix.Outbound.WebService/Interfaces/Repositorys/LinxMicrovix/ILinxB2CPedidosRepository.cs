using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxB2CPedidosRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, LinxB2CPedidos? record);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<LinxB2CPedidos> records);
        public Task<List<LinxB2CPedidos>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<LinxB2CPedidos> registros);
    }
}
