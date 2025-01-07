using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
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

        public Task<List<LinxMotivosDesoneracaoIcms>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMotivosDesoneracaoIcms> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMotivosDesoneracaoIcms? record)
        {
            throw new NotImplementedException();
        }
    }
}
