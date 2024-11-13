using IntegrationsCore.Domain.Entities;
using IntegrationsCore.Domain.Entities.Parameters;
using System.Data;

namespace LinxCommerce.Infrastructure.Repository.Base
{
    public interface ILinxCommerceRepositoryBase<TEntity> where TEntity : class
    {
        public Task<string?> GetParameters(LinxCommerceJobParameter jobParameter);

        public Task<bool> InsertRecord(LinxCommerceJobParameter jobParameter, string? sql, object record);
        public Task<bool> InsertParametersIfNotExists(LinxCommerceJobParameter jobParameter, object parameter);
        public Task<bool> InsertLogResponse(LinxCommerceJobParameter jobParameter, string? response, object record);

        public Task<bool> DeleteLogResponse(LinxCommerceJobParameter jobParameter);

        public Task<bool> ExecuteTruncateRawTable(LinxCommerceJobParameter jobParameter);
        public Task<bool> ExecuteQueryCommand(LinxCommerceJobParameter jobParameter, string? sql);

        public Task<bool> UpdateLogParameters(LinxCommerceJobParameter jobParameter, string? lastResponse);
        public bool BulkInsertIntoTableRaw(LinxCommerceJobParameter jobParameter, DataTable dataTable, int dataTableRowsNumber);

        public Task<bool> CallDbProcMerge(LinxCommerceJobParameter jobParameter);

        public Task<bool> CreateDataTableIfNotExists(LinxCommerceJobParameter jobParameter);
        public DataTable CreateSystemDataTable(LinxCommerceJobParameter jobParameter, TEntity entity);
    }
}
