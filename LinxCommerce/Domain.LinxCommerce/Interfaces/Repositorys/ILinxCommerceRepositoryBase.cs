using Domain.LinxCommerce.Entities.Parameters;
using System.Data;

namespace Domain.LinxCommerce.Interfaces.Repositorys
{
    public interface ILinxCommerceRepositoryBase
    {
        public Task<string?> GetParameters(LinxCommerceJobParameter jobParameter);

        public Task<bool> InsertRecord(LinxCommerceJobParameter jobParameter, string? sql, object record);
        //public Task<bool> InsertParametersIfNotExists(LinxCommerceJobParameter jobParameter, object parameter);

        //public Task<bool> ExecuteTruncateRawTable(LinxCommerceJobParameter jobParameter);
        public Task<bool> ExecuteQueryCommand(LinxCommerceJobParameter jobParameter, string? sql);

        public bool BulkInsertIntoTableRaw(string? jobName, string? dataTableName, string? databaseName, DataTable dataTable, int dataTableRowsNumber);
        public bool BulkInsertIntoTableTrusted(string? jobName, string? dataTableName, string? databaseName, DataTable dataTable, int dataTableRowsNumber);

        public Task<bool> CallDbProcMerge(LinxCommerceJobParameter jobParameter);
        public Task<bool> CallDbProcMerge(string schemaName, string tableName, Guid? parentExecutionGUID);

        //public Task<bool> CreateDataTableIfNotExists(LinxCommerceJobParameter jobParameter);

        public DataTable CreateSystemDataTable<TEntity>(LinxCommerceJobParameter jobParameter, TEntity entity);
        public DataTable CreateSystemDataTable<TEntity>(LinxCommerceJobParameter jobParameter, TEntity entity, string[] columnNames, Type[] columnTypes);
    }
}
