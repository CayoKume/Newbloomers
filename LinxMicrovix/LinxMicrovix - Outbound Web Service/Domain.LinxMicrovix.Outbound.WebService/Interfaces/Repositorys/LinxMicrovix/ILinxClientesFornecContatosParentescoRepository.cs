using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxClientesFornecContatosParentescoRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, LinxClientesFornecContatosParentesco? record);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<LinxClientesFornecContatosParentesco> records);
        public Task<List<LinxClientesFornecContatosParentesco>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<LinxClientesFornecContatosParentesco> registros);
    }
}
