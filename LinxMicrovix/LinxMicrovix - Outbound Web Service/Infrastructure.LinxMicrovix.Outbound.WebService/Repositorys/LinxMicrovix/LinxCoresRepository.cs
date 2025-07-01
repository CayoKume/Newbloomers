using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxCoresRepository : ILinxCoresRepository
    {
        public LinxCoresRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCores> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxCores>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCores> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCores? record)
        {
            throw new NotImplementedException();
        }
    }
}
