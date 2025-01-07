using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxListagemBalancoRepository : ILinxListagemBalancoRepository
    {
        public LinxListagemBalancoRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxListagemBalanco> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxListagemBalanco>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxListagemBalanco> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxListagemBalanco? record)
        {
            throw new NotImplementedException();
        }
    }
}
