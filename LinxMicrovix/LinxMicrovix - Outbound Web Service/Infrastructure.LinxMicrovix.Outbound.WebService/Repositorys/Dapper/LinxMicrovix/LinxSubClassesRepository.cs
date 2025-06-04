using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxSubClassesRepository : ILinxSubClassesRepository
    {
        public LinxSubClassesRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxSubClasses> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxSubClasses>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxSubClasses> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxSubClasses? record)
        {
            throw new NotImplementedException();
        }
    }
}
