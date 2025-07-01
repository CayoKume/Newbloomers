using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxOrdensServicoProdutos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxOrdensServicoProdutos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxOrdensServicoProdutos? record)
        {
            throw new NotImplementedException();
        }
    }
}
