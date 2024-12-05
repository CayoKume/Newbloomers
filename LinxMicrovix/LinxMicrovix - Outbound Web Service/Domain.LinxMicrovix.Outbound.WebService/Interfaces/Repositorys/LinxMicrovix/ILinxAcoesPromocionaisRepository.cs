using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxAcoesPromocionaisRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, LinxAcoesPromocionais? record);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<LinxAcoesPromocionais> records);
        public Task<List<LinxAcoesPromocionais>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<LinxAcoesPromocionais> registros);
    }
}
