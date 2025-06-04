using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaTiposCobrancaFreteRepository
    {
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaTiposCobrancaFrete> records);
        public Task<List<B2CConsultaTiposCobrancaFrete>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaTiposCobrancaFrete> registros);
    }
}
