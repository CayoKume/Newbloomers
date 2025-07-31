using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxNFeEventoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxNFeEvento? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxNFeEvento> records);
        public Task<IEnumerable<LinxNFeEvento>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxNFeEvento> registros);
    }
}
