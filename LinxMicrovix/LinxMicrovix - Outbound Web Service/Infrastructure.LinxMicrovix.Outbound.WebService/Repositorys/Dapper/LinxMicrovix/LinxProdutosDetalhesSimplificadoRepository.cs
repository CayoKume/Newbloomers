using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
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
