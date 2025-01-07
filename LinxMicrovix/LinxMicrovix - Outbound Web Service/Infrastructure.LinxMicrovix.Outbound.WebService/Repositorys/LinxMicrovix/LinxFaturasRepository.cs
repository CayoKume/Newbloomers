using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxFaturasRepository : ILinxFaturasRepository
    {
        public LinxFaturasRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxFaturas> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxFaturas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxFaturas> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxFaturas? record)
        {
            throw new NotImplementedException();
        }
    }
}
