using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaProdutosStatusRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaProdutosStatus? record);
        public Task<bool> InsertParametersIfNotExists(LinxMicrovixJobParameter jobParameter);
        public Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<B2CConsultaProdutosStatus> records);
        public Task<List<B2CConsultaProdutosStatus>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, IList<B2CConsultaProdutosStatus> registros);
    }
}
