using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
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
