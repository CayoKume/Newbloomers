using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxCstIpiFiscalRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCstIpiFiscal? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCstIpiFiscal> records);
        public Task<IEnumerable<LinxCstIpiFiscal>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCstIpiFiscal> registros);
    }
}
