using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxPagamentoParcialDavRepository : ILinxPagamentoParcialDavRepository
    {
        public LinxPagamentoParcialDavRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPagamentoParcialDav> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxPagamentoParcialDav>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPagamentoParcialDav> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPagamentoParcialDav? record)
        {
            throw new NotImplementedException();
        }
    }
}
