using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxClasseFiscalRepository : ILinxClasseFiscalRepository
    {
        public LinxClasseFiscalRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClasseFiscal> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxClasseFiscal>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClasseFiscal> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClasseFiscal? record)
        {
            throw new NotImplementedException();
        }
    }
}
