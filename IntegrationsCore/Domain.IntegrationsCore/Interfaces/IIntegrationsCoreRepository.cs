using Domain.IntegrationsCore.Models.Errors;
using System.Data;

namespace Domain.IntegrationsCore.Interfaces
{
    public interface IIntegrationsCoreRepository
    {
        public void FillSystemDataTable<TEntity>(DataTable dataTable, List<TEntity> data);
        public DataTable CreateSystemDataTable<TEntity>(string? tableName, TEntity entity);
        public bool BulkInsertIntoTableRaw(DataTable dataTable);
        public Task<bool> LogInsert(Log log);
    }
}
