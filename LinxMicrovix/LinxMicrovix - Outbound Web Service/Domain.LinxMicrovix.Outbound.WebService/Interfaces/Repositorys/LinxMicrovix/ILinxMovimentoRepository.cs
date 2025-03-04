using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimento? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimento> records);
        public Task<List<LinxMovimento>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimento?> registros);
    }
}
