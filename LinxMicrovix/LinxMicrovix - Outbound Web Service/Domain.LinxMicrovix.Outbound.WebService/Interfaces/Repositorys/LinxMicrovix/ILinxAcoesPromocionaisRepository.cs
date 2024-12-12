using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxAcoesPromocionaisRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxAcoesPromocionais? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxAcoesPromocionais> records);
        public Task<List<LinxAcoesPromocionais>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxAcoesPromocionais> registros);
    }
}
