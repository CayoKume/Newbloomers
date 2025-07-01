using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxEspessurasRepository : ILinxEspessurasRepository
    {
        public LinxEspessurasRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxEspessuras> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxEspessuras>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxEspessuras> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxEspessuras? record)
        {
            throw new NotImplementedException();
        }
    }
}
