using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxLojasParametrosRepository : ILinxLojasParametrosRepository
    {
        public LinxLojasParametrosRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxLojasParametros> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxLojasParametros>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxLojasParametros> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxLojasParametros? record)
        {
            throw new NotImplementedException();
        }
    }
}
