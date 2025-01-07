using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxRotinaOrigemRepository : ILinxRotinaOrigemRepository
    {
        public LinxRotinaOrigemRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxRotinaOrigem> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxRotinaOrigem>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxRotinaOrigem> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxRotinaOrigem? record)
        {
            throw new NotImplementedException();
        }
    }
}
