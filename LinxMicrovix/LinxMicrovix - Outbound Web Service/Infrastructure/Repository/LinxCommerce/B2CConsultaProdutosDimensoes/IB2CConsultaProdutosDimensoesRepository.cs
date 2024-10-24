using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public interface IB2CConsultaProdutosDimensoesRepository<TEntity> where TEntity : class, new()
    {
        public Task<bool> InsertRecord(JobParameter jobParameter, TEntity? record);
        public Task<bool> InsertParametersIfNotExists(JobParameter jobParameter);
        public Task<bool> ExecuteTableMerge(JobParameter jobParameter);
        public bool BulkInsertIntoTableRaw(JobParameter jobParameter, List<TEntity> records);
    }
}
