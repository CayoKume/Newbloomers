using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxCestRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, LinxCest? record);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<LinxCest> records);
        public Task<List<LinxCest>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<LinxCest> registros);
    }
}
