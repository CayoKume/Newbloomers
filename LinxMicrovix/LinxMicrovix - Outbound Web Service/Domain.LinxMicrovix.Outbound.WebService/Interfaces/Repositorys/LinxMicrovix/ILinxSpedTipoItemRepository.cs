using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxSpedTipoItemRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxSpedTipoItem? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxSpedTipoItem> records);
        public Task<List<LinxSpedTipoItem>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxSpedTipoItem> registros);
    }
}
