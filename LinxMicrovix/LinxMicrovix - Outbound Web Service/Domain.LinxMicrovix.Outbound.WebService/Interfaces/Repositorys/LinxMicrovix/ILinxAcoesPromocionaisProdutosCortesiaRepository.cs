using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxAcoesPromocionaisProdutosCortesiaRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, LinxAcoesPromocionaisProdutosCortesia? record);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<LinxAcoesPromocionaisProdutosCortesia> records);
        public Task<List<LinxAcoesPromocionaisProdutosCortesia>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<LinxAcoesPromocionaisProdutosCortesia> registros);
    }
}
