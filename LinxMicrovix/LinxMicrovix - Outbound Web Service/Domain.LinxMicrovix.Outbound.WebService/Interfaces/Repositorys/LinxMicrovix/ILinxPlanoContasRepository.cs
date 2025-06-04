using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxPlanoContasRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPlanoContas? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPlanoContas> records);
        public Task<List<LinxPlanoContas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPlanoContas> registros);
    }
}
