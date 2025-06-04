using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoExtensaoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoExtensao? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoExtensao> records);
        public Task<List<LinxMovimentoExtensao>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoExtensao> registros);
    }
}
