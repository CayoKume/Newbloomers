using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoPrincipalRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoPrincipal? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoPrincipal> records);
        public Task<IEnumerable<LinxMovimentoPrincipal>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoPrincipal> registros);
    }
}
