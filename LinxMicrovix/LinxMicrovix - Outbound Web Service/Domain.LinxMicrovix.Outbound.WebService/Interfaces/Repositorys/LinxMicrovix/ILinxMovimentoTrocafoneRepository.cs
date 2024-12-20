using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoTrocafoneRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoTrocafone? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoTrocafone> records);
        public Task<List<LinxMovimentoTrocafone>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoTrocafone> registros);
    }
}
