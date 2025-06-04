using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxNfceEstacaoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxNfceEstacao? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxNfceEstacao> records);
        public Task<List<LinxNfceEstacao>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxNfceEstacao> registros);
    }
}
