using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxMovimentoObservacoes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoObservacoes> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoObservacoes? record)
        {
            throw new NotImplementedException();
        }
    }
}
