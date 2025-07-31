using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoOrigemDevolucoesRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoOrigemDevolucoes? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoOrigemDevolucoes> records);
        public Task<IEnumerable<LinxMovimentoOrigemDevolucoes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoOrigemDevolucoes> registros);
    }
}
