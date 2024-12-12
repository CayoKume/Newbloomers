using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxClientesFornecContatosParentescoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClientesFornecContatosParentesco? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClientesFornecContatosParentesco> records);
        public Task<List<LinxClientesFornecContatosParentesco>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClientesFornecContatosParentesco> registros);
    }
}
