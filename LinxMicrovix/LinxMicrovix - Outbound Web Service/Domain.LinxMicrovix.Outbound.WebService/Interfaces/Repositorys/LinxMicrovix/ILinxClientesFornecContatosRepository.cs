using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxClientesFornecContatosRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, LinxClientesFornecContatos? record);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<LinxClientesFornecContatos> records);
        public Task<List<LinxClientesFornecContatos>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<LinxClientesFornecContatos> registros);
    }
}
