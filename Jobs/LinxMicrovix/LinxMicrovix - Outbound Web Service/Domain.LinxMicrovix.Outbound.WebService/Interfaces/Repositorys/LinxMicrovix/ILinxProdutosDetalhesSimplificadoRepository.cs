using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxProdutosDetalhesSimplificadoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosDetalhesSimplificado? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosDetalhesSimplificado> records);
        public Task<IEnumerable<LinxProdutosDetalhesSimplificado>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosDetalhesSimplificado> registros);
    }
}
