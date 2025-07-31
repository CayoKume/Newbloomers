using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxCoresRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCores? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCores> records);
        public Task<IEnumerable<LinxCores>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCores> registros);
    }
}
