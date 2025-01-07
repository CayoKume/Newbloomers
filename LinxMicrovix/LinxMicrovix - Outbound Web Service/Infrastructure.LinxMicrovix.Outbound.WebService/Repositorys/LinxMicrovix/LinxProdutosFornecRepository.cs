using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxProdutosFornecRepository : ILinxProdutosFornecRepository
    {
        public LinxProdutosFornecRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosFornec> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxProdutosFornec>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosFornec> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosFornec? record)
        {
            throw new NotImplementedException();
        }
    }
}
