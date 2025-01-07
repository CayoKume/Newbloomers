using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
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

        public Task<List<LinxMovimentoIndicacoes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoIndicacoes> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoIndicacoes? record)
        {
            throw new NotImplementedException();
        }
    }
}
