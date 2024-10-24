using IntegrationsCore.Domain.Entities;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public interface IB2CConsultaFormasPagamentoRepository<TEntity> where TEntity : class, new()
    {
        public Task<bool> InsertParametersIfNotExists(JobParameter jobParameter);
        public Task<bool> ExecuteTableMerge(JobParameter jobParameter);
        public bool BulkInsertIntoTableRaw(JobParameter jobParameter, List<TEntity> records);
    }
}
