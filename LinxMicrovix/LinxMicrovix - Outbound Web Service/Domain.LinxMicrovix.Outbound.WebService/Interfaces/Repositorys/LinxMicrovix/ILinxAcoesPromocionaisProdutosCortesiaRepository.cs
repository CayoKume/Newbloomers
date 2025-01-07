using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxAcoesPromocionaisProdutosCortesiaRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxAcoesPromocionaisProdutosCortesia? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxAcoesPromocionaisProdutosCortesia> records);
        public Task<List<LinxAcoesPromocionaisProdutosCortesia>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxAcoesPromocionaisProdutosCortesia> registros);
    }
}
