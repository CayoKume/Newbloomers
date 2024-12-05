using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxClientesFornecClassesRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, LinxClientesFornecClasses? record);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<LinxClientesFornecClasses> records);
        public Task<List<LinxClientesFornecClasses>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<LinxClientesFornecClasses> registros);
    }
}
