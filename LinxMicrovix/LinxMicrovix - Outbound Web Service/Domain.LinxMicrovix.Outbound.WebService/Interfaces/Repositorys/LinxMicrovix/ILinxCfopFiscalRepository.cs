using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxCfopFiscalRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, LinxCfopFiscal? record);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<LinxCfopFiscal> records);
        public Task<List<LinxCfopFiscal>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<LinxCfopFiscal> registros);
    }
}
