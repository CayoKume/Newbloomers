using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
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
