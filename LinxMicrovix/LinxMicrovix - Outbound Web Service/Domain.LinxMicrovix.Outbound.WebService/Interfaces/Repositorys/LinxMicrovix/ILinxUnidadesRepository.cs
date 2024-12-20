using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxUnidadesRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxUnidades? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxUnidades> records);
        public Task<List<LinxUnidades>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxUnidades> registros);
    }
}
