using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaClientesContatosRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaClientesContatos? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaClientesContatos> records);
        public Task<List<B2CConsultaClientesContatos>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaClientesContatos> registros);
    }
}
