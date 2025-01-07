using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaEspessurasRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaEspessuras? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaEspessuras> records);
        public Task<List<B2CConsultaEspessuras>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaEspessuras> registros);
    }
}
