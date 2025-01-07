using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
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

        public Task<List<LinxPagamentoParcialDav>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPagamentoParcialDav> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPagamentoParcialDav? record)
        {
            throw new NotImplementedException();
        }
    }
}
