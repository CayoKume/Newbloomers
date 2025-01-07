using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxClassificacoesRepository : ILinxClassificacoesRepository
    {
        public LinxClassificacoesRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClassificacoes> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxClassificacoes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClassificacoes> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClassificacoes? record)
        {
            throw new NotImplementedException();
        }
    }
}
