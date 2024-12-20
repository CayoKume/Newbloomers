using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaNFeRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaNFe? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaNFe> records);
        public Task<List<B2CConsultaNFe>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaNFe> registros);
    }
}
