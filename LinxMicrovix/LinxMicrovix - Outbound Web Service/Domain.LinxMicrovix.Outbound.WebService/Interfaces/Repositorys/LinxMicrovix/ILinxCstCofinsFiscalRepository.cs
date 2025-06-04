using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxCstCofinsFiscalRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCstCofinsFiscal? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCstCofinsFiscal> records);
        public Task<List<LinxCstCofinsFiscal>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCstCofinsFiscal> registros);
    }
}
