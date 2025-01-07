using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMovimentoGiftCardRepository : ILinxMovimentoGiftCardRepository
    {
        public LinxMovimentoGiftCardRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoGiftCard> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMovimentoGiftCard>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoGiftCard> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoGiftCard? record)
        {
            throw new NotImplementedException();
        }
    }
}
