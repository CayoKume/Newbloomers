using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxAcoesPromocionaisCombinacaoProdutosItensRepository : ILinxAcoesPromocionaisCombinacaoProdutosItensRepository
    {
        public LinxAcoesPromocionaisCombinacaoProdutosItensRepository()
        {
            
        }


        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxAcoesPromocionaisCombinacaoProdutosItens> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxAcoesPromocionaisCombinacaoProdutosItens>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxAcoesPromocionaisCombinacaoProdutosItens> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxAcoesPromocionaisCombinacaoProdutosItens? record)
        {
            throw new NotImplementedException();
        }
    }
}
