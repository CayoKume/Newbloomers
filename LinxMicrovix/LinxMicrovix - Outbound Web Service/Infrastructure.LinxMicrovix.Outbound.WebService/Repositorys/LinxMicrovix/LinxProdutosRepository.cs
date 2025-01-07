using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxProdutosRepository : ILinxProdutosRepository
    {
        public LinxProdutosRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutos> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxProdutos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutos? record)
        {
            throw new NotImplementedException();
        }
    }
}
