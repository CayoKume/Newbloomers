using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxProdutosFornecRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosFornec? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosFornec> records);
        public Task<IEnumerable<LinxProdutosFornec>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosFornec> registros);
    }
}
