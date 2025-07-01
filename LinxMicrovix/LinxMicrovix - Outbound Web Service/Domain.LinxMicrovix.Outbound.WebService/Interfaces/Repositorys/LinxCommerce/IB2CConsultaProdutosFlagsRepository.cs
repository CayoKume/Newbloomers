using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaProdutosFlagsRepository
    {
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosFlags> records);
        public Task<IEnumerable<B2CConsultaProdutosFlags>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosFlags> registros);
    }
}
