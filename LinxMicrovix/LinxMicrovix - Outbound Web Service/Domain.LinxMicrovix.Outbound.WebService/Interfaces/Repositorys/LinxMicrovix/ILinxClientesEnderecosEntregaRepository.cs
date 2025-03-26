using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxClientesEnderecosEntregaRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClientesEnderecosEntrega? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClientesEnderecosEntrega> records);
        public Task<List<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<int?> registros);
    }
}
