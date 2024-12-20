using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaColecoesRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaColecoes? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaColecoes> records);
        public Task<List<B2CConsultaColecoes>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaColecoes> registros);
    }
}
