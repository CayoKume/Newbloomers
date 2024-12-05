using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxClientesFornecCamposAdicionaisRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, LinxClientesFornecCamposAdicionais? record);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<LinxClientesFornecCamposAdicionais> records);
        public Task<List<LinxClientesFornecCamposAdicionais>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<LinxClientesFornecCamposAdicionais> registros);
    }
}
