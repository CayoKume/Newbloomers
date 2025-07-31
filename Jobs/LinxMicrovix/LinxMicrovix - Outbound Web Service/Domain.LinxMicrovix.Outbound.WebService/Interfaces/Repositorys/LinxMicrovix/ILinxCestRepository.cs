using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxCestRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCest? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCest> records);
        public Task<IEnumerable<LinxCest>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCest> registros);
    }
}
