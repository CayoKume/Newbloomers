using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxFidelidadeRepository : ILinxFidelidadeRepository
    {
        public LinxFidelidadeRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxFidelidade> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxFidelidade>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxFidelidade> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxFidelidade? record)
        {
            throw new NotImplementedException();
        }
    }
}
