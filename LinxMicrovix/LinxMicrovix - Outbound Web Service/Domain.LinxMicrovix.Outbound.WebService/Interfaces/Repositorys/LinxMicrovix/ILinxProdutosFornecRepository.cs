using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxProdutosFornecRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosFornec? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosFornec> records);
        public Task<List<LinxProdutosFornec>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosFornec> registros);
    }
}
