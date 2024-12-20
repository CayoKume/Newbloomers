using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaClientesSaldoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaClientesSaldo? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaClientesSaldo> records);
        public Task<List<B2CConsultaClientesSaldo>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaClientesSaldo> registros);
    }
}
