using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaTipoEncomendaRepository
    {
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaTipoEncomenda> records);
        public Task<List<B2CConsultaTipoEncomenda>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaTipoEncomenda> registros);
    }
}
