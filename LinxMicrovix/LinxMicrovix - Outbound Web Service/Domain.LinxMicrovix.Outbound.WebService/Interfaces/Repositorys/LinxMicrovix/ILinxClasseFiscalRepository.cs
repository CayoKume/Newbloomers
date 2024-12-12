using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxClasseFiscalRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClasseFiscal? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClasseFiscal> records);
        public Task<List<LinxClasseFiscal>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClasseFiscal> registros);
    }
}
