using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxCentroCustoRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, LinxCentroCusto? record);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<LinxCentroCusto> records);
        public Task<List<LinxCentroCusto>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<LinxCentroCusto> registros);
    }
}
