using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxMovimentoPrincipalRepository : ILinxMovimentoPrincipalRepository
    {
        public LinxMovimentoPrincipalRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoPrincipal> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxMovimentoPrincipal>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoPrincipal> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoPrincipal? record)
        {
            throw new NotImplementedException();
        }
    }
}
