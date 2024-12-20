using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxProdutosDepositosRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosDepositos? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosDepositos> records);
        public Task<List<LinxProdutosDepositos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosDepositos> registros);
    }
}
