using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxPlanosBandeirasRepository : ILinxPlanosBandeirasRepository
    {
        public LinxPlanosBandeirasRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPlanosBandeiras> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxPlanosBandeiras>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPlanosBandeiras> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPlanosBandeiras? record)
        {
            throw new NotImplementedException();
        }
    }
}
