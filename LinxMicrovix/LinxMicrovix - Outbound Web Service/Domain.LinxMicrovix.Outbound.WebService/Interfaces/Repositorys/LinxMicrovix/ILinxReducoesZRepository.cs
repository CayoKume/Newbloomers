using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxReducoesZRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxReducoesZ? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxReducoesZ> records);
        public Task<List<LinxReducoesZ>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxReducoesZ> registros);
    }
}
