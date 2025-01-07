using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxOrdensServicoProdutosRepository : ILinxOrdensServicoProdutosRepository
    {
        public LinxOrdensServicoProdutosRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxOrdensServicoProdutos> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxOrdensServicoProdutos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxOrdensServicoProdutos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxOrdensServicoProdutos? record)
        {
            throw new NotImplementedException();
        }
    }
}
