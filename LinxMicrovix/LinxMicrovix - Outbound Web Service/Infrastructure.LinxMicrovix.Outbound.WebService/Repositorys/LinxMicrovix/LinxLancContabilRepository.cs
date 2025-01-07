using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxLancContabilRepository : ILinxLancContabilRepository
    {
        public LinxLancContabilRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxLancContabil> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxLancContabil>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxLancContabil> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxLancContabil? record)
        {
            throw new NotImplementedException();
        }
    }
}
