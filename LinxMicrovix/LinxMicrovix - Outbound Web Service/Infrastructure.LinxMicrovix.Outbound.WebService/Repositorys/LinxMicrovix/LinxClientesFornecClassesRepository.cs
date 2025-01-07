using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxClientesFornecClassesRepository : ILinxClientesFornecClassesRepository
    {
        public LinxClientesFornecClassesRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClientesFornecClasses> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxClientesFornecClasses>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClientesFornecClasses> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClientesFornecClasses? record)
        {
            throw new NotImplementedException();
        }
    }
}
