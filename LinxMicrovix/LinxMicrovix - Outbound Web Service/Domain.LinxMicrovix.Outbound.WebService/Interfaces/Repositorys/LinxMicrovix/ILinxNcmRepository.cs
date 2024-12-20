using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxNcmRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxNcm? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxNcm> records);
        public Task<List<LinxNcm>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxNcm> registros);
    }
}
