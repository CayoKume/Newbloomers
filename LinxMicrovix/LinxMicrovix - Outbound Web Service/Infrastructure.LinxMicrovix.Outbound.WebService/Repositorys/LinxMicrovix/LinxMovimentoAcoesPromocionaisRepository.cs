using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMovimentoAcoesPromocionaisRepository : ILinxMovimentoAcoesPromocionaisRepository
    {
        public LinxMovimentoAcoesPromocionaisRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoAcoesPromocionais> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMovimentoAcoesPromocionais>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoAcoesPromocionais> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoAcoesPromocionais? record)
        {
            throw new NotImplementedException();
        }
    }
}
