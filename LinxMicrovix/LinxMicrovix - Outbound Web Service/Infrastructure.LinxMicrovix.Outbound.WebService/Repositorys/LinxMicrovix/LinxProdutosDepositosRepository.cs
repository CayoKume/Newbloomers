using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxProdutosDepositosRepository : ILinxProdutosDepositosRepository
    {
        public LinxProdutosDepositosRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosDepositos> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxProdutosDepositos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosDepositos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosDepositos? record)
        {
            throw new NotImplementedException();
        }
    }
}
