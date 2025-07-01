using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxRemessasOperacoesRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxRemessasOperacoes? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxRemessasOperacoes> records);
        public Task<IEnumerable<LinxRemessasOperacoes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxRemessasOperacoes> registros);
    }
}
