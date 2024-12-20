using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaEmpresasRepository
    {
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaEmpresas> records);
        public Task<List<B2CConsultaEmpresas>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaEmpresas> registros);
    }
}
