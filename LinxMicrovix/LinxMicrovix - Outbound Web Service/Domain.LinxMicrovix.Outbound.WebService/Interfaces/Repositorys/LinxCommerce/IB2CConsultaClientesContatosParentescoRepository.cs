using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaClientesContatosParentescoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaClientesContatosParentesco? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaClientesContatosParentesco> records);
        public Task<List<B2CConsultaClientesContatosParentesco>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaClientesContatosParentesco> registros);
    }
}
