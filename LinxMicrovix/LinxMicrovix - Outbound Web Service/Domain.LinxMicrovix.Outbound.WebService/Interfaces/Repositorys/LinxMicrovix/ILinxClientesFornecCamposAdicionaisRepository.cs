using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxClientesFornecCamposAdicionaisRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClientesFornecCamposAdicionais? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClientesFornecCamposAdicionais> records);
        public Task<List<LinxClientesFornecCamposAdicionais>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClientesFornecCamposAdicionais> registros);
    }
}
