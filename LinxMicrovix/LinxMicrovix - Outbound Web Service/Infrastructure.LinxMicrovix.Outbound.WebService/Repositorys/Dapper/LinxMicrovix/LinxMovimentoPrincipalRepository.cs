using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
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

        public Task<List<LinxMovimentoPrincipal>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoPrincipal> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoPrincipal? record)
        {
            throw new NotImplementedException();
        }
    }
}
