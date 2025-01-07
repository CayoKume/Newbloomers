using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxSpedTipoItemRepository : ILinxSpedTipoItemRepository
    {
        public LinxSpedTipoItemRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxSpedTipoItem> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxSpedTipoItem>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxSpedTipoItem> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxSpedTipoItem? record)
        {
            throw new NotImplementedException();
        }
    }
}
