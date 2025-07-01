using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxValeOrdemServicoExternaRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxValeOrdemServicoExterna? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxValeOrdemServicoExterna> records);
        public Task<IEnumerable<LinxValeOrdemServicoExterna>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxValeOrdemServicoExterna> registros);

    }
}
