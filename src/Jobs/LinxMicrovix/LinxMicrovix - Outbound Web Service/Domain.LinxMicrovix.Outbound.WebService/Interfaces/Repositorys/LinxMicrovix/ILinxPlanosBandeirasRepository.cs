using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxPlanosBandeirasRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPlanosBandeiras? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPlanosBandeiras> records);
        public Task<IEnumerable<LinxPlanosBandeiras>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPlanosBandeiras> registros);
    }
}
