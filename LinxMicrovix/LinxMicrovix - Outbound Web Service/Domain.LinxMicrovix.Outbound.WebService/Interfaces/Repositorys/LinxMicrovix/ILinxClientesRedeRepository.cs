using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxClientesRedeRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClientesRede? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClientesRede> records);
        public Task<List<LinxClientesRede>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClientesRede> registros);
    }
}
