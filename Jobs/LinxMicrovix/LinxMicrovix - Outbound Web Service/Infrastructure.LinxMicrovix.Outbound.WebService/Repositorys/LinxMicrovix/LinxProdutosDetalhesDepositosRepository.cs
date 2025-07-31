using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxProdutosDetalhesDepositos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosDetalhesDepositos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosDetalhesDepositos? record)
        {
            throw new NotImplementedException();
        }
    }
}
