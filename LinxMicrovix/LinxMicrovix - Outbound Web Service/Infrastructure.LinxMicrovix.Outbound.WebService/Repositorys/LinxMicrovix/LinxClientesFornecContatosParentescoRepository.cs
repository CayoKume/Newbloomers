using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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
