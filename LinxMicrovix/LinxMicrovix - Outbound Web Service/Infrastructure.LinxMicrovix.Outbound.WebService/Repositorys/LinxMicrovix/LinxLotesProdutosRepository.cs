using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
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

        public Task<List<LinxLotesProdutos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxLotesProdutos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxLotesProdutos? record)
        {
            throw new NotImplementedException();
        }
    }
}
