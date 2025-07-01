using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxLancContabilRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxLancContabil? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxLancContabil> records);
        public Task<IEnumerable<LinxLancContabil>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxLancContabil> registros);
    }
}
