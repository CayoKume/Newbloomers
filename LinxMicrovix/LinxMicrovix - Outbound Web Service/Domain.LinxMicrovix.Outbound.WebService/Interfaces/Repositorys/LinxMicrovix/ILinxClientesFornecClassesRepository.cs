using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxClientesFornecClassesRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClientesFornecClasses? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClientesFornecClasses> records);
        public Task<List<LinxClientesFornecClasses>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClientesFornecClasses> registros);
    }
}
