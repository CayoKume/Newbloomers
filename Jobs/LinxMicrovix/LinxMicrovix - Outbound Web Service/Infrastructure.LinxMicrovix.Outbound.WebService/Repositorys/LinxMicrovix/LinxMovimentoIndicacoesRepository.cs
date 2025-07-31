using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxMovimentoIndicacoesRepository : ILinxMovimentoIndicacoesRepository
    {
        public LinxMovimentoIndicacoesRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoIndicacoes> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxMovimentoIndicacoes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoIndicacoes> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoIndicacoes? record)
        {
            throw new NotImplementedException();
        }
    }
}
