using Domain.LinxMicrovix.Outbound.WebService.Entites.Base;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using System.Data;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base
{
    public interface ILinxMicrovixAzureSQLRepositoryBase<TEntity> where TEntity : class
    {
        public Task<string?> GetLastMaxTimestampByCnpjAndIdentificador(string? schema, string? tableName, string? columnCompany, string? companyValue, string? columnIdentificador, string? columnIdentificadorValue);
        public Task<string?> GetLastMaxTimestamp(string? schema, string? tableName, string? columnCompany, string? companyValue);
        public Task<string?> GetLast7DaysMaxTimestamp(string? schema, string? tableName);
        public Task<string?> GetLast7DaysMinTimestamp(string? schema, string? tableName, string? columnDate);
        public Task<string?> GetLast7DaysMinTimestamp(string? schema, string? tableName, string? columnDate, string? columnCompany, string? companyValue);

        public Task<string?> GetParameters(string? parametersInterval, string? parametersTableName, string? jobName);
        public Task<IEnumerable<string?>> GetParameters(string sql);

        public Task<IEnumerable<Company>> GetB2CCompanys();
        public Task<IEnumerable<Company>> GetMicrovixCompanys();
        public Task<IEnumerable<Company>> GetMicrovixGroupCompanys();

        public Task<bool> CallDbProcMerge(string schemaName, string tableName, Guid? parentExecutionGUID);
        public Task<List<string>> GetKeyRegistersAlreadyExists(string sql);
        public Task<List<TEntity>> GetRegistersExists(string sql);
        public Task<bool> InsertRecord(string tableName, string? sql, object record);
        public Task<bool> ExecuteQueryCommand(string? sql);
        public bool BulkInsertIntoTableRaw(DataTable dataTable, int dataTableRowsNumber);
        public DataTable CreateSystemDataTable(string? tableName, TEntity entity);
    }
}
