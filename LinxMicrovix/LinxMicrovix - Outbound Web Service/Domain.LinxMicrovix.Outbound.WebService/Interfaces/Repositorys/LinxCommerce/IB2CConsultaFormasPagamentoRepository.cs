using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaFormasPagamentoRepository
    {
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaFormasPagamento> records);
        public Task<IEnumerable<B2CConsultaFormasPagamento>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaFormasPagamento> registros);
    }
}
