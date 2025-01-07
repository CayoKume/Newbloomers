using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxCsosnFiscalRepository : ILinxCsosnFiscalRepository
    {
        public LinxCsosnFiscalRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCsosnFiscal> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxCsosnFiscal>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCsosnFiscal> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCsosnFiscal? record)
        {
            throw new NotImplementedException();
        }
    }
}
