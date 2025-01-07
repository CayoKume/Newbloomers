using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxPlanosRepository : ILinxPlanosRepository
    {
        public LinxPlanosRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPlanos> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxPlanos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPlanos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPlanos? record)
        {
            throw new NotImplementedException();
        }
    }
}
