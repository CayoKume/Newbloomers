using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxProdutosPromocoesRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosPromocoes? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosPromocoes> records);
        public Task<List<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<Int64?> registros);
    }
}
