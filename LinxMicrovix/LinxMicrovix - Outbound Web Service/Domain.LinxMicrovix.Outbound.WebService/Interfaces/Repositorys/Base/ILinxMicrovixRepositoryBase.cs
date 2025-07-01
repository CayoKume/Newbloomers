using Domain.LinxMicrovix.Outbound.WebService.Entities.Base;
using System.Data;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base
{
    public interface ILinxMicrovixRepositoryBase<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get the last max timestamp value by CNPJ and Identificador from DataTable
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="tableName"></param>
        /// <param name="columnCompany"></param>
        /// <param name="companyValue"></param>
        /// <param name="columnIdentificador"></param>
        /// <param name="columnIdentificadorValue"></param>
        public Task<string?> GetLastMaxTimestampByCnpjAndIdentificador(string? schema, string? tableName, string? columnCompany, string? companyValue, string? columnIdentificador, string? columnIdentificadorValue);
        /// <summary>
        /// Get the last max timestamp value from DataTable by company
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="tableName"></param>
        /// <param name="columnCompany">Can be cnpj_emp or company</param>
        /// <param name="companyValue">Can be cnpj or company number</param>
        public Task<string?> GetLastMaxTimestamp(string? schema, string? tableName, string? columnCompany, string? companyValue);
        /// <summary>
        /// Get the last 7 days max timestamp value without column date from DataTable
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="tableName"></param>
        public Task<string?> GetLast7DaysMaxTimestamp(string? schema, string? tableName);
        /// <summary>
        /// Get the last 7 days min timestamp value with column date from DataTable
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="tableName"></param>
        /// <param name="columnDate">Can be lastupdateon, order date or any other date column</param>
        public Task<string?> GetLast7DaysMinTimestamp(string? schema, string? tableName, string? columnDate);
        /// <summary>
        /// Get the last 7 days min timestamp value by company and date from DataTable
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="tableName"></param>
        /// <param name="columnDate">Can be lastupdateon, order date or any other date column</param>
        /// <param name="columnCompany">Can be cnpj_emp or company</param>
        /// <param name="companyValue">Can be cnpj or company number</param>
        public Task<string?> GetLast7DaysMinTimestamp(string? schema, string? tableName, string? columnDate, string? columnCompany, string? companyValue);

        /// <summary>
        /// Get Parameters from Database LinxAPIParam Table
        /// </summary>
        /// <param name="parametersInterval"></param>
        /// <param name="parametersTableName"></param>
        /// <param name="jobName"></param>
        public Task<string?> GetParameters(string? parametersInterval, string? parametersTableName, string? jobName);
        /// <summary>
        /// Get Parameters from Database Tables (ex: LinxProdutosDepositos, LinxProdutosTabelas, LinxSetores)
        /// </summary>
        /// <param name="sql"></param>
        public Task<IEnumerable<string?>> GetParameters(string sql);

        /// <summary>
        /// Get Companys from Database B2CConsultaEmpresas Table
        /// </summary>
        public Task<IEnumerable<Company?>> GetB2CCompanys();
        /// <summary>
        /// Get Companys from Database LinxLojas Table
        /// </summary>
        public Task<IEnumerable<Company?>> GetMicrovixCompanys();
        /// <summary>
        /// Get Companys from Database LinxGrupoLojas Table
        /// </summary>
        public Task<IEnumerable<Company?>> GetMicrovixGroupCompanys();

        /// <summary>
        /// Get keys from registers that already existis from database for chaching
        /// </summary>
        /// <param name="sql"></param>
        public Task<IEnumerable<string?>> GetKeyRegistersAlreadyExists(string sql);
        /// <summary>
        /// Get registers that already existis from Database
        /// </summary>
        /// <param name="sql"></param>
        public Task<IEnumerable<TEntity?>> GetRegistersExists(string sql);

        /// <summary>
        /// Insert Record to Database
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="sql"></param>
        /// <param name="record"></param>
        public Task<bool> InsertRecord(string tableName, string? sql, object record);
        /// <summary>
        /// Execute simple sql query in Database
        /// </summary>
        /// <param name="sql"></param>
        public Task<bool> ExecuteQueryCommand(string? sql);
        /// <summary>
        /// Call synchronization procedure from Database
        /// </summary>
        /// <param name="schemaName"></param>
        /// <param name="tableName"></param>
        /// <param name="parentExecutionGUID"></param>
        public Task<bool> CallDbProcMerge(string schemaName, string tableName, Guid? parentExecutionGUID);
        /// <summary>
        /// Execute bulk insert on Database
        /// </summary>
        /// <param name="dataTable"></param>
        public bool BulkInsertIntoTableRaw(DataTable dataTable);
        /// <summary>
        /// Create a System DATA .NET DataTable
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="entity"></param>
        public DataTable CreateSystemDataTable(string? tableName, TEntity entity);
    }
}
