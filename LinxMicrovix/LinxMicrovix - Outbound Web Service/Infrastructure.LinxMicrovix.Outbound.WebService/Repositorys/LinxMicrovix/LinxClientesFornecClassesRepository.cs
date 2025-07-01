using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxClientesFornecClasses>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClientesFornecClasses> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClientesFornecClasses? record)
        {
            throw new NotImplementedException();
        }
    }
}
