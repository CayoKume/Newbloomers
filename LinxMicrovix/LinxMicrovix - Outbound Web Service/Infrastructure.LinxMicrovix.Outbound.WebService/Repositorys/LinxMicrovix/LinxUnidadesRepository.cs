using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxUnidadesRepository : ILinxUnidadesRepository
    {
        public LinxUnidadesRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxUnidades> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxUnidades>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxUnidades> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxUnidades? record)
        {
            throw new NotImplementedException();
        }
    }
}
