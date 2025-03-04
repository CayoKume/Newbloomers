using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxProdutosPromocoesRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosPromocoes? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosPromocoes> records);
        public Task<List<LinxProdutosPromocoes>> GetRegistersExists(LinxAPIParam jobParameter, List<Int64?> registros);
    }
}
