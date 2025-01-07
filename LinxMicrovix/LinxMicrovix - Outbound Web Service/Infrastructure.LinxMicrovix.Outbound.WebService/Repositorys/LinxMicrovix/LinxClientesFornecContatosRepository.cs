using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxClientesFornecContatosRepository : ILinxClientesFornecContatosRepository
    {
        public LinxClientesFornecContatosRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClientesFornecContatos> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxClientesFornecContatos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClientesFornecContatos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClientesFornecContatos? record)
        {
            throw new NotImplementedException();
        }
    }
}
