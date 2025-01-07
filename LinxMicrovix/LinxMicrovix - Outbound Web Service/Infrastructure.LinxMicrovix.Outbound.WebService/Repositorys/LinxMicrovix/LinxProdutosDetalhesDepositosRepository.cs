using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxProdutosDetalhesDepositosRepository : ILinxProdutosDetalhesDepositosRepository
    {
        public LinxProdutosDetalhesDepositosRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosDetalhesDepositos> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxProdutosDetalhesDepositos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosDetalhesDepositos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosDetalhesDepositos? record)
        {
            throw new NotImplementedException();
        }
    }
}
