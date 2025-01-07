using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxCfopFiscalRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCfopFiscal? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCfopFiscal> records);
        public Task<List<LinxCfopFiscal>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCfopFiscal> registros);
    }
}
