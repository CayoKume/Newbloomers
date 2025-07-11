using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaPedidosTiposRepository
    {
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaPedidosTipos> records);
        public Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaPedidosTipos> registros);
    }
}
