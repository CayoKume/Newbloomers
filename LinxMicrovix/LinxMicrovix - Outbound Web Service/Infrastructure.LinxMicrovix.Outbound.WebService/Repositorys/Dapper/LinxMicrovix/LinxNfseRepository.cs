using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxNfseRepository : ILinxNfseRepository
    {
        public LinxNfseRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxNfse> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxNfse>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxNfse> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxNfse? record)
        {
            throw new NotImplementedException();
        }
    }
}
