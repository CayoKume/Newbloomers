using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxB2CStatusRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxB2CStatus? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxB2CStatus> records);
        public Task<List<string?>> GetRegistersExists();
    }
}
