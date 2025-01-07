using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxProdutosLotesRepository : ILinxProdutosLotesRepository
    {
        public LinxProdutosLotesRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosLotes> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxProdutosLotes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosLotes> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosLotes? record)
        {
            throw new NotImplementedException();
        }
    }
}
