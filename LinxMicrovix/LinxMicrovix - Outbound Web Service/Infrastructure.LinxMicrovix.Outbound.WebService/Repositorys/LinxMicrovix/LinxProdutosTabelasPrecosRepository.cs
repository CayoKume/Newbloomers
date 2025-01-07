using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxProdutosTabelasPrecosRepository : ILinxProdutosTabelasPrecosRepository
    {
        public LinxProdutosTabelasPrecosRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosTabelasPrecos> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxProdutosTabelasPrecos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosTabelasPrecos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosTabelasPrecos? record)
        {
            throw new NotImplementedException();
        }
    }
}
