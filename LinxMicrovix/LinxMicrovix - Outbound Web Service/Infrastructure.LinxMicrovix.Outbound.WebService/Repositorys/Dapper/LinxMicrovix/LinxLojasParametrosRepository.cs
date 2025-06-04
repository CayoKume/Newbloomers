using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxLojasParametrosRepository : ILinxLojasParametrosRepository
    {
        public LinxLojasParametrosRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxLojasParametros> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxLojasParametros>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxLojasParametros> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxLojasParametros? record)
        {
            throw new NotImplementedException();
        }
    }
}
