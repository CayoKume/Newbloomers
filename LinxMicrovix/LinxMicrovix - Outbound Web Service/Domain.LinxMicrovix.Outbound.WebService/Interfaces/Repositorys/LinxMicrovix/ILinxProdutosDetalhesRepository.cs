using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxProdutosDetalhesRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosDetalhes? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosDetalhes> records);
        public Task<List<LinxProdutosDetalhes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosDetalhes> registros);
    }
}
