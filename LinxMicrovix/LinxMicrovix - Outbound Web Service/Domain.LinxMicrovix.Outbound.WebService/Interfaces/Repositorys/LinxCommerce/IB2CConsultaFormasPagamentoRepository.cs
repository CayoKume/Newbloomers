using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaFormasPagamentoRepository
    {
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaFormasPagamento> records);
        public Task<List<B2CConsultaFormasPagamento>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaFormasPagamento> registros);
    }
}
