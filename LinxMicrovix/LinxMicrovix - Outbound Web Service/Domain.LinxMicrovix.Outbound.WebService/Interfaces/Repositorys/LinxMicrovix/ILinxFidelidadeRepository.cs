using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxFidelidadeRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxFidelidade? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxFidelidade> records);
        public Task<List<LinxFidelidade>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxFidelidade> registros);
    }
}
