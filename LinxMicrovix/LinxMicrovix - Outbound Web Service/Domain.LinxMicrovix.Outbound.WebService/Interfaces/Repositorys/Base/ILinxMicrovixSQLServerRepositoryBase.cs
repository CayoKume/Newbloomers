using Domain.LinxMicrovix.Outbound.WebService.Entites.Base;
using System.Data;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base
{
    public interface ILinxMicrovixSQLServerRepositoryBase<TEntity> where TEntity : class
    {
        public Task<string?> GetLast7DaysMinTimestamp(string? schema, string? tableName, string? columnDate, string? databaseName);
        public Task<string?> GetLast7DaysMinTimestamp(string? schema, string? tableName, string? columnDate, string? columnCompany, string? companyValue, string? databaseName);

        public Task<string?> GetParameters(string? parametersInterval, string? parametersTableName, string? jobName, string databaseName);
        public Task<IEnumerable<string?>> GetParameters(string sql, string databaseName);
        
        public Task<IEnumerable<Company>> GetB2CCompanys(string databaseName);
        public Task<IEnumerable<Company>> GetMicrovixCompanys(string databaseName);
        public Task<IEnumerable<Company>> GetMicrovixGroupCompanys(string databaseName);
        
        public Task<bool> CallDbProcMerge(string databaseName, string tableName);
        public Task<bool> InsertRecord(string? tableName, string? sql, string databaseName, object record);
        public DataTable CreateSystemDataTable(string? tableName, TEntity entity);
        public Task<List<TEntity>> GetRegistersExists(string sql, string? databaseName);
        public Task<bool> ExecuteQueryCommand(string? sql, string? databaseName);
        public bool BulkInsertIntoTableRaw(DataTable dataTable, int dataTableRowsNumber, string? databaseName);
    }
}
