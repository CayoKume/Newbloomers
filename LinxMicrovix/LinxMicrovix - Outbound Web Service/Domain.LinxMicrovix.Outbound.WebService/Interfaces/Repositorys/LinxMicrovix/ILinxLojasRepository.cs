using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxLojasRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxLojas? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxLojas> records);
        public Task<List<LinxLojas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxLojas> registros);
    }
}
