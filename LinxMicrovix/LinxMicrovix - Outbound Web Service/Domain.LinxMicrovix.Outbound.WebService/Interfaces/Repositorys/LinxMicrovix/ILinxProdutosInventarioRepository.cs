using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxProdutosInventarioRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosInventario? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosInventario> records);
        public Task<IEnumerable<string?>> GetProductsDepositsIds(LinxAPIParam jobParameter);
        public Task<List<LinxProdutosInventario>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosInventario> registros);
    }
}
