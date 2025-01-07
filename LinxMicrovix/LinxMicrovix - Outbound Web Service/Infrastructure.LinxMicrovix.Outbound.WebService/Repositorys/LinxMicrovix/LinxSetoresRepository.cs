using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxSetoresRepository : ILinxSetoresRepository
    {
        public LinxSetoresRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxSetores> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxSetores>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxSetores> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxSetores? record)
        {
            throw new NotImplementedException();
        }
    }
}
