using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public interface IB2CConsultaProdutosDetalhesRepository<TEntity> where TEntity : class, new()
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, TEntity? record);
        public Task<bool> InsertParametersIfNotExists(LinxMicrovixJobParameter jobParameter);
        public Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<TEntity> records);
    }
}
