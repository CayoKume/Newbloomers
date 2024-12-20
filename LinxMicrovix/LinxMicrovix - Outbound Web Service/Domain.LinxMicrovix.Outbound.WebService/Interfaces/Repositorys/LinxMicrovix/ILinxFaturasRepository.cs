using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxFaturasRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxFaturas? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxFaturas> records);
        public Task<List<LinxFaturas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxFaturas> registros);
    }
}
