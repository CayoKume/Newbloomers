using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxECFFormasPagamentoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxECFFormasPagamento? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxECFFormasPagamento> records);
        public Task<IEnumerable<LinxECFFormasPagamento>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxECFFormasPagamento> registros);
    }
}
