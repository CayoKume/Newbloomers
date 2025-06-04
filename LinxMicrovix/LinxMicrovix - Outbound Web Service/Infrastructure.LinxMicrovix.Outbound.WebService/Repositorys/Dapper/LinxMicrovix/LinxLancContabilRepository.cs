using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxLancContabilRepository : ILinxLancContabilRepository
    {
        public LinxLancContabilRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxLancContabil> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxLancContabil>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxLancContabil> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxLancContabil? record)
        {
            throw new NotImplementedException();
        }
    }
}
