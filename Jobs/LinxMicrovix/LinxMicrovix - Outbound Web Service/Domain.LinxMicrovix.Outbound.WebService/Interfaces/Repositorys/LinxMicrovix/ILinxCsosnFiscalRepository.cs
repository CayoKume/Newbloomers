using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxCsosnFiscalRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCsosnFiscal? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCsosnFiscal> records);
        public Task<IEnumerable<LinxCsosnFiscal>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCsosnFiscal> registros);
    }
}
