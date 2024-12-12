using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxB2CStatusRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxB2CStatus? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxB2CStatus> records);
        public Task<List<LinxB2CStatus>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxB2CStatus> registros);
    }
}
