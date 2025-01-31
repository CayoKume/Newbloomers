using Domain.LinxCommerce.Entities.Parameters;
using System.Data;

namespace Domain.LinxCommerce.Interfaces.Repositorys.Base
{
    public interface ILinxCommerceRepositoryBase
    {
        public Task<string?> GetParameters(LinxCommerceJobParameter jobParameter);

        public Task<bool> InsertRecord(LinxCommerceJobParameter jobParameter, string? sql, object record);
        public Task<bool> InsertParametersIfNotExists(LinxCommerceJobParameter jobParameter, object parameter);
        //public Task<bool> InsertLogResponse(LinxCommerceJobParameter jobParameter, string? response, object record);

        //public Task<bool> DeleteLogResponse(LinxCommerceJobParameter jobParameter);

        public Task<bool> ExecuteTruncateRawTable(LinxCommerceJobParameter jobParameter);
        public Task<bool> ExecuteQueryCommand(LinxCommerceJobParameter jobParameter, string? sql);

        //public Task<bool> UpdateLogParameters(LinxCommerceJobParameter jobParameter, string? lastResponse);
        public bool BulkInsertIntoTableRaw(LinxCommerceJobParameter jobParameter, DataTable dataTable, int dataTableRowsNumber);

        public Task<bool> CallDbProcMerge(LinxCommerceJobParameter jobParameter);

        public Task<bool> CreateDataTableIfNotExists(LinxCommerceJobParameter jobParameter);
        //public DataTable CreateSystemDataTable(LinxCommerceJobParameter jobParameter, TEntity entity);

        public DataTable CreateSystemDataTable<TEntity>(LinxCommerceJobParameter jobParameter, TEntity entity);
    }
}
