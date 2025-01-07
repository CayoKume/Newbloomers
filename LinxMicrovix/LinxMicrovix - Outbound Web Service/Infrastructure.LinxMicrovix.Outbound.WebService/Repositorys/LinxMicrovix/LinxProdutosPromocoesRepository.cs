using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxProdutosPromocoesRepository : ILinxProdutosPromocoesRepository
    {
        public LinxProdutosPromocoesRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosPromocoes> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxProdutosPromocoes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosPromocoes> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosPromocoes? record)
        {
            throw new NotImplementedException();
        }
    }
}
