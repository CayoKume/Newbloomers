using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxOrdensServicoProdutosRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxOrdensServicoProdutos? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxOrdensServicoProdutos> records);
        public Task<List<LinxOrdensServicoProdutos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxOrdensServicoProdutos> registros);
    }
}
