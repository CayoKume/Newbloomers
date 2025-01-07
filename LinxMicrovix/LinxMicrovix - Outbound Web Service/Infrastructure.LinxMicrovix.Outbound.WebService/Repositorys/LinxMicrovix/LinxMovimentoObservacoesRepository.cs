using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMovimentoObservacoesRepository : ILinxMovimentoObservacoesRepository
    {
        public LinxMovimentoObservacoesRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoObservacoes> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMovimentoObservacoes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoObservacoes> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoObservacoes? record)
        {
            throw new NotImplementedException();
        }
    }
}
