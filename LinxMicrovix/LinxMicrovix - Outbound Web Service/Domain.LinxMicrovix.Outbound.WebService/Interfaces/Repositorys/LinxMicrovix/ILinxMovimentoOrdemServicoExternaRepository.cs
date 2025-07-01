using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoOrdemServicoExternaRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoOrdemServicoExterna? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoOrdemServicoExterna> records);
        public Task<IEnumerable<LinxMovimentoOrdemServicoExterna>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoOrdemServicoExterna> registros);
    }
}
