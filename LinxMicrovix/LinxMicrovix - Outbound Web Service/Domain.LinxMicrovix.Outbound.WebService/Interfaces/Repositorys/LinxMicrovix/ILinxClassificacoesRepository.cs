using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxClassificacoesRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClassificacoes? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClassificacoes> records);
        public Task<List<LinxClassificacoes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClassificacoes> registros);
    }
}
