using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxClasseFiscalRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, LinxClasseFiscal? record);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<LinxClasseFiscal> records);
        public Task<List<LinxClasseFiscal>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<LinxClasseFiscal> registros);
    }
}
