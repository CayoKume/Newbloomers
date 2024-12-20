using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaClientesEstadoCivilRepository
    {
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaClientesEstadoCivil> records);
        public Task<List<B2CConsultaClientesEstadoCivil>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaClientesEstadoCivil> registros);
    }
}
