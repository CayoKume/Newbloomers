using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
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
