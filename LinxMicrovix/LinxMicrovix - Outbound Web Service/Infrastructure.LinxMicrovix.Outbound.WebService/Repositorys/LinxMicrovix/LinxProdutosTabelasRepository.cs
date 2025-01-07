using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxProdutosTabelasRepository : ILinxProdutosTabelasRepository
    {
        public LinxProdutosTabelasRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosTabelas> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxProdutosTabelas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosTabelas> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosTabelas? record)
        {
            throw new NotImplementedException();
        }
    }
}
