using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaProdutosDetalhesDepositosRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosDetalhesDepositos? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosDetalhesDepositos> records);
        public Task<List<B2CConsultaProdutosDetalhesDepositos>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosDetalhesDepositos> registros);
    }
}
