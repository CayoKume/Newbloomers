using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxProdutosDetalhesSimplificadoRepository : ILinxProdutosDetalhesSimplificadoRepository
    {
        public LinxProdutosDetalhesSimplificadoRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosDetalhesSimplificado> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxProdutosDetalhesSimplificado>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosDetalhesSimplificado> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosDetalhesSimplificado? record)
        {
            throw new NotImplementedException();
        }
    }
}
