using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxClientesRedeRepository : ILinxClientesRedeRepository
    {
        public LinxClientesRedeRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClientesRede> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxClientesRede>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClientesRede> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClientesRede? record)
        {
            throw new NotImplementedException();
        }
    }
}
