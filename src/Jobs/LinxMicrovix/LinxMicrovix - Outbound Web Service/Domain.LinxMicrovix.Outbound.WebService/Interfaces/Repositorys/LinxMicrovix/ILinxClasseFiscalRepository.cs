using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxClasseFiscalRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClasseFiscal? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClasseFiscal> records);
        public Task<IEnumerable<LinxClasseFiscal>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClasseFiscal> registros);
    }
}
