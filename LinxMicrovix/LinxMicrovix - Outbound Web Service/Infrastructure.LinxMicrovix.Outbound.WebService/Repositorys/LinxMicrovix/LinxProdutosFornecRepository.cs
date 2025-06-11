using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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
