using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaProdutosFlagsRepository
    {
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosFlags> records);
        public Task<List<B2CConsultaProdutosFlags>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosFlags> registros);
    }
}
