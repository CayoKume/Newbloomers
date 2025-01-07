using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxB2CStatusRepository : ILinxB2CStatusRepository
    {
        public LinxB2CStatusRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxB2CStatus> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxB2CStatus>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxB2CStatus> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxB2CStatus? record)
        {
            throw new NotImplementedException();
        }
    }
}
