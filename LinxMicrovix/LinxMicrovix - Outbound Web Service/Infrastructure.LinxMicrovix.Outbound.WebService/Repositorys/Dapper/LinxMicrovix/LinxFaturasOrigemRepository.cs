using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxFaturasOrigemRepository : ILinxFaturasOrigemRepository
    {
        public LinxFaturasOrigemRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxFaturasOrigem> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxFaturasOrigem>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxFaturasOrigem> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxFaturasOrigem? record)
        {
            throw new NotImplementedException();
        }
    }
}
