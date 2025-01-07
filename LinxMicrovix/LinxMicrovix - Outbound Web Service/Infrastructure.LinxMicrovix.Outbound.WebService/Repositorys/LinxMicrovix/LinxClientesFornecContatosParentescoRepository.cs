using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxClientesFornecContatosParentescoRepository : ILinxClientesFornecContatosParentescoRepository
    {
        public LinxClientesFornecContatosParentescoRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClientesFornecContatosParentesco> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxClientesFornecContatosParentesco>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClientesFornecContatosParentesco> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClientesFornecContatosParentesco? record)
        {
            throw new NotImplementedException();
        }
    }
}
