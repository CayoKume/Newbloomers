using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;
using System.Data;
using System.Reflection;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base
{
    public interface ILinxMicrovixRepositoryBase<TEntity> where TEntity : class
    {
        public Task<string> GetParameters(JobParameter jobParameter);
        public Task<IEnumerable<Company>> GetB2CCompanys(JobParameter jobParameter);
        public Task<IEnumerable<Company>> GetMicrovixCompanys(JobParameter jobParameter);
        public Task<string> GetLast7DaysMinTimestamp(JobParameter jobParameter, string? columnDate);

        public Task<bool> InsertRecord(JobParameter jobParameter, string? sql, object record);
        public Task<bool> InsertParametersIfNotExists(JobParameter jobParameter, object parameter);
        public Task<bool> InsertLogResponse(JobParameter jobParameter, string? response, object record);

        public Task<bool> DeleteLogResponse(JobParameter jobParameter);

        public Task<bool> ExecuteTruncateRawTable(JobParameter jobParameter);
        public Task<bool> ExecuteQueryCommand(JobParameter jobParameter, string sql);

        public Task<bool> UpdateLogParameters(JobParameter jobParameter, string? lastResponse);
        public bool BulkInsertIntoTableRaw(JobParameter jobParameter, DataTable dataTable, int dataTableRowsNumber);

        public Task<bool> CallDbProcMerge(JobParameter jobParameter);

        public Task<bool> CreateDataTableIfNotExists(JobParameter jobParameter);
        public DataTable CreateSystemDataTable(JobParameter jobParameter, TEntity entity);
    }
}
