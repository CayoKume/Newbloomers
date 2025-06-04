using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxCfopFiscalRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCfopFiscal? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCfopFiscal> records);
        public Task<List<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<Int32> registros);
    }
}
