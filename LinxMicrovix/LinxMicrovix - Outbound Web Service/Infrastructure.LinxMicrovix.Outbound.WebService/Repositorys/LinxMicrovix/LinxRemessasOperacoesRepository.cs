using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxRemessasOperacoesRepository : ILinxRemessasOperacoesRepository
    {
        public LinxRemessasOperacoesRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxRemessasOperacoes> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxRemessasOperacoes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxRemessasOperacoes> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxRemessasOperacoes? record)
        {
            throw new NotImplementedException();
        }
    }
}
