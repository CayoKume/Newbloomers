using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaClientesSaldoLinxRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaClientesSaldoLinx? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaClientesSaldoLinx> records);
        public Task<List<B2CConsultaClientesSaldoLinx>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaClientesSaldoLinx> registros);
    }
}
