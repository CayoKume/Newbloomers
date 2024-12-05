using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxB2CStatusRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, LinxB2CStatus? record);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<LinxB2CStatus> records);
        public Task<List<LinxB2CStatus>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<LinxB2CStatus> registros);
    }
}
