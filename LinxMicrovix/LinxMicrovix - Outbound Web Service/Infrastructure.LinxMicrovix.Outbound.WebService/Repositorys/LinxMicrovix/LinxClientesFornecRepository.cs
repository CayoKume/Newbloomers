using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxClientesFornecRepository : ILinxClientesFornecRepository
    {
        public LinxClientesFornecRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClientesFornec> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxClientesFornec>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClientesFornec> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClientesFornec? record)
        {
            throw new NotImplementedException();
        }
    }
}
