using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxCestRepository : ILinxCestRepository
    {
        public LinxCestRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCest> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxCest>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCest> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCest? record)
        {
            throw new NotImplementedException();
        }
    }
}
