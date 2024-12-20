using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMotivoDescontoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMotivoDesconto? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMotivoDesconto> records);
        public Task<List<LinxMotivoDesconto>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMotivoDesconto> registros);
    }
}
