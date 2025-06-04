using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxAcoesPromocionaisProdutosCortesiaRepository : ILinxAcoesPromocionaisProdutosCortesiaRepository
    {
        public LinxAcoesPromocionaisProdutosCortesiaRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxAcoesPromocionaisProdutosCortesia> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxAcoesPromocionaisProdutosCortesia>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxAcoesPromocionaisProdutosCortesia> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxAcoesPromocionaisProdutosCortesia? record)
        {
            throw new NotImplementedException();
        }
    }
}
