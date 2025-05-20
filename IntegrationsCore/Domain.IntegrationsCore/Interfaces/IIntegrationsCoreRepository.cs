using Domain.IntegrationsCore.Entities.Errors;
using System.Data;

namespace Domain.IntegrationsCore.Interfaces
{
    public interface IIntegrationsCoreRepository
    {
        public DataTable CreateSystemDataTable<TEntity>(string? tableName, TEntity entity);
        public bool BulkInsertIntoTableRaw(DataTable dataTable, int dataTableRowsNumber, string? databaseName);
        public Task<bool> LogInsert(Log log);
    }
}
