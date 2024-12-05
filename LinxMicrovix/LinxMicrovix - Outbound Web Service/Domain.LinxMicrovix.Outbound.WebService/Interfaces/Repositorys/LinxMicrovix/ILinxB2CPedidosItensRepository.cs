using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxB2CPedidosItensRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, LinxB2CPedidosItens? record);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<LinxB2CPedidosItens> records);
        public Task<List<LinxB2CPedidosItens>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<LinxB2CPedidosItens> registros);
    }
}
