using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxECFFormasPagamentoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxECFFormasPagamento? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxECFFormasPagamento> records);
        public Task<List<LinxECFFormasPagamento>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxECFFormasPagamento> registros);
    }
}
