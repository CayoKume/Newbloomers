using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoSerialRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoSerial? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoSerial> records);
        public Task<List<LinxMovimentoSerial>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoSerial> registros);
    }
}
