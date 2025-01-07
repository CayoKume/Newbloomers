using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxCstCofinsFiscalRepository : ILinxCstCofinsFiscalRepository
    {
        public LinxCstCofinsFiscalRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCstCofinsFiscal> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxCstCofinsFiscal>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCstCofinsFiscal> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCstCofinsFiscal? record)
        {
            throw new NotImplementedException();
        }
    }
}
