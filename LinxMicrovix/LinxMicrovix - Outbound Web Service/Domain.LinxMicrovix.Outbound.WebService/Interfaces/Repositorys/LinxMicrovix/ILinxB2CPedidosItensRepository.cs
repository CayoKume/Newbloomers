using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxB2CPedidosItensRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxB2CPedidosItens? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxB2CPedidosItens> records);
        public Task<List<LinxB2CPedidosItens>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxB2CPedidosItens> registros);
    }
}
