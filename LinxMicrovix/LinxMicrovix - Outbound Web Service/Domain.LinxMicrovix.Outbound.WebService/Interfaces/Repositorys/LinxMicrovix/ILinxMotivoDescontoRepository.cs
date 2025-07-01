using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMotivoDescontoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMotivoDesconto? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMotivoDesconto> records);
        public Task<IEnumerable<LinxMotivoDesconto>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMotivoDesconto> registros);
    }
}
