using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxCstIpiFiscalRepository : ILinxCstIpiFiscalRepository
    {
        public LinxCstIpiFiscalRepository()
        {
            
        }
        
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCstIpiFiscal> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxCstIpiFiscal>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCstIpiFiscal> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCstIpiFiscal? record)
        {
            throw new NotImplementedException();
        }
    }
}
