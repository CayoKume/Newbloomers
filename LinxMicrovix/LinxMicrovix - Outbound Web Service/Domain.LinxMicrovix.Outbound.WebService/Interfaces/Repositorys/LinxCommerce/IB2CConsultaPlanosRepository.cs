using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaPlanosRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaPlanos? record);
        public Task<bool> InsertParametersIfNotExists(LinxMicrovixJobParameter jobParameter);
        public Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<B2CConsultaPlanos> records);
        public Task<List<B2CConsultaPlanos>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<B2CConsultaPlanos> registros);
    }
}
