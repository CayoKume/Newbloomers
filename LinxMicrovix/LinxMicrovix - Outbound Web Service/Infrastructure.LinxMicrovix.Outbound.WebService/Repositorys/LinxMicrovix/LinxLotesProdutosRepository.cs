using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxLotesProdutosRepository : ILinxLotesProdutosRepository
    {
        public LinxLotesProdutosRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxLotesProdutos> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxLotesProdutos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxLotesProdutos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxLotesProdutos? record)
        {
            throw new NotImplementedException();
        }
    }
}
