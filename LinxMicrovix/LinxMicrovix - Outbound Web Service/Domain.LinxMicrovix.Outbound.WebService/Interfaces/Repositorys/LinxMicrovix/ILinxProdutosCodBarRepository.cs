using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix_Outbound_Web_Service.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix_Outbound_Web_Service.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxProdutosCodBarRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, LinxProdutosCodBar? record);
        public Task<bool> InsertParametersIfNotExists(LinxMicrovixJobParameter jobParameter);
        public Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<LinxProdutosCodBar> records);
    }
}
