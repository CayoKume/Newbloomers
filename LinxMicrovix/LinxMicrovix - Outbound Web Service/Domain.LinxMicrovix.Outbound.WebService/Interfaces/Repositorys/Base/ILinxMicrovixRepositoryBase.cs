using Domain.LinxMicrovix.Outbound.WebService.Entites.Base;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using System.Data;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base
{
    public interface ILinxMicrovixRepositoryBase<TEntity> where TEntity : class
    {
        public Task<string?> GetParameters(LinxAPIParam jobParameter);
        public Task<IEnumerable<Company>> GetB2CCompanys(LinxAPIParam jobParameter);
        public Task<IEnumerable<Company>> GetMicrovixCompanys(LinxAPIParam jobParameter);
        public Task<List<TEntity>> GetRegistersExists(LinxAPIParam jobParameter, string sql);
        public Task<string?> GetLast7DaysMinTimestamp(LinxAPIParam jobParameter, string? columnDate);
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, string? sql, object record);
        public Task<bool> ExecuteQueryCommand(LinxAPIParam jobParameter, string? sql);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, DataTable dataTable, int dataTableRowsNumber);
        public Task<bool> CallDbProcMerge(LinxAPIParam jobParameter);
        public DataTable CreateSystemDataTable(LinxAPIParam jobParameter, TEntity entity);

        #region MOVER PARA PROJETO DATABASE INITIALIZATION
        public Task<bool> InsertParametersIfNotExists(LinxAPIParam jobParameter, object parameter);
        //public Task<bool> InsertLogResponse(LinxAPIParam jobParameter, string? response, object record);
        //public Task<bool> DeleteLogResponse(LinxAPIParam jobParameter);
        //public Task<bool> ExecuteTruncateRawTable(LinxAPIParam jobParameter);
        //public Task<bool> UpdateLogParameters(LinxAPIParam jobParameter, string? lastResponse);
        //public Task<bool> CreateDataTableIfNotExists(LinxAPIParam jobParameter);
        #endregion
    }
}
