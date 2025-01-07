using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxLojasRepository : ILinxLojasRepository
    {
        public LinxLojasRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxLojas> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxLojas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxLojas> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxLojas? record)
        {
            throw new NotImplementedException();
        }
    }
}
