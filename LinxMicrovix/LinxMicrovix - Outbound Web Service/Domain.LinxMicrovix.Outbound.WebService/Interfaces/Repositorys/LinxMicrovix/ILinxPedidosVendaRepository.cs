using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxPedidosVendaRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPedidosVenda? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPedidosVenda> records);
        public Task<List<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<int?> registros);
    }
}
