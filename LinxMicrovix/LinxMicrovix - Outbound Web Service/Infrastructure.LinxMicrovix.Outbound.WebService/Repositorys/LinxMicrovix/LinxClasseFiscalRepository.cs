using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
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
