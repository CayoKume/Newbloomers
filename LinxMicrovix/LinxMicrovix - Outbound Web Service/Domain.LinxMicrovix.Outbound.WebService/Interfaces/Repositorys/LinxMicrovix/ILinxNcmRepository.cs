using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxNcmRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxNcm? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxNcm> records);
        public Task<IEnumerable<LinxNcm>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxNcm> registros);
    }
}
