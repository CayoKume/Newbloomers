using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoGiftCardRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoGiftCard? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoGiftCard> records);
        public Task<IEnumerable<LinxMovimentoGiftCard>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoGiftCard> registros);
    }
}
