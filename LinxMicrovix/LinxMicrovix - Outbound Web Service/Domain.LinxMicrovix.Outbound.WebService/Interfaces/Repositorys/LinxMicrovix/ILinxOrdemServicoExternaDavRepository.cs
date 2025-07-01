using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxOrdemServicoExternaDavRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxOrdemServicoExternaDav? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxOrdemServicoExternaDav> records);
        public Task<IEnumerable<LinxOrdemServicoExternaDav>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxOrdemServicoExternaDav> registros);
    }
}
