using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaClientesEnderecosEntregaRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaClientesEnderecosEntrega? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaClientesEnderecosEntrega> records);
        public Task<List<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<int?> registros);
    }
}
