using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxCentroCustoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCentroCusto? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCentroCusto> records);
        public Task<List<LinxCentroCusto>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCentroCusto> registros);
    }
}
