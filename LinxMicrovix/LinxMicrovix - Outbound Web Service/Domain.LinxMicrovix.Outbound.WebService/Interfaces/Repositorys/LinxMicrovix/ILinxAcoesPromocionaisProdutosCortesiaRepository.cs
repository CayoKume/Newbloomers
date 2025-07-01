using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxAcoesPromocionaisProdutosCortesiaRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxAcoesPromocionaisProdutosCortesia? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxAcoesPromocionaisProdutosCortesia> records);
        public Task<IEnumerable<LinxAcoesPromocionaisProdutosCortesia>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxAcoesPromocionaisProdutosCortesia> registros);
    }
}
