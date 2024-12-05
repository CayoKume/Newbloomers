using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxAcoesPromocionaisCombinacaoProdutosItensRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, LinxAcoesPromocionaisCombinacaoProdutosItens? record);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<LinxAcoesPromocionaisCombinacaoProdutosItens> records);
        public Task<List<LinxAcoesPromocionaisCombinacaoProdutosItens>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<LinxAcoesPromocionaisCombinacaoProdutosItens> registros);
    }
}
