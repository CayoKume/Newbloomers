using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxAcoesPromocionaisCombinacaoProdutosItens>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxAcoesPromocionaisCombinacaoProdutosItens> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxAcoesPromocionaisCombinacaoProdutosItens? record)
        {
            throw new NotImplementedException();
        }
    }
}
