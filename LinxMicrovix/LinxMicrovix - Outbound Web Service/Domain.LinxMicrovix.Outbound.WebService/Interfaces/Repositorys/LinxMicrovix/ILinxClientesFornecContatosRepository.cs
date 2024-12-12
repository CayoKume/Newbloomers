using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxClientesFornecContatosRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClientesFornecContatos? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClientesFornecContatos> records);
        public Task<List<LinxClientesFornecContatos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClientesFornecContatos> registros);
    }
}
