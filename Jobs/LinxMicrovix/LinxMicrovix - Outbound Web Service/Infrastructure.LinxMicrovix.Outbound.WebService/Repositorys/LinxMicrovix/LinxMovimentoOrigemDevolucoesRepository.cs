using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxMovimentoOrigemDevolucoes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoOrigemDevolucoes> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoOrigemDevolucoes? record)
        {
            throw new NotImplementedException();
        }
    }
}
