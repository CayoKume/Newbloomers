using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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
