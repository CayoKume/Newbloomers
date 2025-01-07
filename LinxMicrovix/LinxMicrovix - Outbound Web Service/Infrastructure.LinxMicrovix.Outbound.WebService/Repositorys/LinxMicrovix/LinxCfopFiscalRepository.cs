using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxCfopFiscalRepository : ILinxCfopFiscalRepository
    {
        public LinxCfopFiscalRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCfopFiscal> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxCfopFiscal>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCfopFiscal> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCfopFiscal? record)
        {
            throw new NotImplementedException();
        }
    }
}
