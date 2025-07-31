using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxFidelidade>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxFidelidade> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxFidelidade? record)
        {
            throw new NotImplementedException();
        }
    }
}
