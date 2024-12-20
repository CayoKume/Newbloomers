using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoAcoesPromocionaisRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoAcoesPromocionais? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoAcoesPromocionais> records);
        public Task<List<LinxMovimentoAcoesPromocionais>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoAcoesPromocionais> registros);
    }
}
