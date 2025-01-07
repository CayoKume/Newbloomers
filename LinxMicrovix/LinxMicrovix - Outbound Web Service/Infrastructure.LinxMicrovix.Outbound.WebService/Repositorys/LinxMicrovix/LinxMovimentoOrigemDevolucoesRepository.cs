using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMovimentoOrigemDevolucoesRepository : ILinxMovimentoOrigemDevolucoesRepository
    {
        public LinxMovimentoOrigemDevolucoesRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoOrigemDevolucoes> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMovimentoOrigemDevolucoes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoOrigemDevolucoes> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoOrigemDevolucoes? record)
        {
            throw new NotImplementedException();
        }
    }
}
