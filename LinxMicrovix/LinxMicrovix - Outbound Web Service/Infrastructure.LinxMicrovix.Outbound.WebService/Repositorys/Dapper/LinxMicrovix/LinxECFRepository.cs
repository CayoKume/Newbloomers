using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxECFRepository : ILinxECFRepository
    {
        public LinxECFRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxECF> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxECF>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxECF> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxECF? record)
        {
            throw new NotImplementedException();
        }
    }
}
