using Domain.Core.Entities.Auditing;
using System.Data;
using static Dapper.SqlMapper;

namespace Domain.Core.Interfaces
{
    public interface ICoreRepository
    {
        /// <summary>
        /// Get register that already existis from Database
        /// </summary>
        /// <param name="sql"></param>
        public Task<TEntity?> GetRecord<TEntity>(string? sql);
        /// <summary>
        /// Get registers that already existis from Database
        /// </summary>
        /// <param name="sql"></param>
        public Task<IEnumerable<TEntity?>> GetRecords<TEntity>(string? sql);

        /// <summary>
        /// Create a System DATA .NET DataTable
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="entity"></param>
        public DataTable CreateSystemDataTable<TEntity>(string? tableName, TEntity entity);
        /// <summary>
        /// Fill System DataTable with data from a list of entities
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="data"></param>
        public void FillSystemDataTable<TEntity>(DataTable dataTable, List<TEntity> data);

        /// <summary>
        /// Execute simple sql query in Database
        /// </summary>
        /// <param name="sql"></param>
        public Task<bool> ExecuteCommand(string? sql);

        /// <summary>
        /// Insert Record to Database
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="entity"></param>
        public Task<bool> InsertRecord(string? sql, object entity);
        /// <summary>
        /// Execute bulk insert on untreated schema from Database
        /// </summary>
        /// <param name="dataTable"></param>
        public bool BulkInsertIntoTableRaw(DataTable dataTable);
        /// <summary>
        /// Execute bulk insert on specific schema from Database
        /// </summary>
        /// <param name="dataTable"></param>
        public bool BulkInsertIntoTableRaw(DataTable dataTable, string schema);
        /// <summary>
        /// Execute bulk insert on specific schema from Database
        /// </summary>
        /// <param name="dataTable"></param>
        public bool BulkInsertIntoTableRaw<TEntity>(List<TEntity> recordsList, TEntity entity, string tableName);
        /// <summary>
        /// Call synchronization procedure from Database
        /// </summary>
        /// <param name="schemaName"></param>
        /// <param name="tableName"></param>
        /// <param name="parentExecutionGUID"></param>
        public Task<bool> CallDbProcMerge(string schemaName, string tableName, Guid? parentExecutionGUID);
        /// <summary>
        /// Call synchronization procedure from Database
        /// </summary>
        /// <param name="schemaName"></param>
        /// <param name="tableName"></param>
        public Task<bool> CallDbProcMerge(string schemaName, string tableName);

        public Task<bool> LogInsert(Log log);
    }
}
