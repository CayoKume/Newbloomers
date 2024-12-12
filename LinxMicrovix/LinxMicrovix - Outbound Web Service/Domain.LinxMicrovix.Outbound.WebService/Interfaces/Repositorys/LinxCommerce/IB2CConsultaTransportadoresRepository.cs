using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaTransportadoresRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaTransportadores? record);
        public Task<bool> InsertParametersIfNotExists(LinxAPIParam jobParameter);
        public Task<bool> CreateTableMerge(LinxAPIParam jobParameter);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaTransportadores> records);
        public Task<List<B2CConsultaTransportadores>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaTransportadores> registros);
    }
}
