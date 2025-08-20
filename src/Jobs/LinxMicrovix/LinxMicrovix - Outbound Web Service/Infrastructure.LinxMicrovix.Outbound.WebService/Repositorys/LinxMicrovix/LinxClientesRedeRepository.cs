using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxClientesRede>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClientesRede> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClientesRede? record)
        {
            throw new NotImplementedException();
        }
    }
}
