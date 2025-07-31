using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxMotivosDesoneracaoIcmsRepository : ILinxMotivosDesoneracaoIcmsRepository
    {
        public LinxMotivosDesoneracaoIcmsRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMotivosDesoneracaoIcms> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxMotivosDesoneracaoIcms>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMotivosDesoneracaoIcms> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMotivosDesoneracaoIcms? record)
        {
            throw new NotImplementedException();
        }
    }
}
