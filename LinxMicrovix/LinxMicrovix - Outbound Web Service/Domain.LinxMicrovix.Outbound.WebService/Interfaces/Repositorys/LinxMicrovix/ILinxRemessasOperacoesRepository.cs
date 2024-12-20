using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxRemessasOperacoesRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxRemessasOperacoes? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxRemessasOperacoes> records);
        public Task<List<LinxRemessasOperacoes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxRemessasOperacoes> registros);
    }
}
