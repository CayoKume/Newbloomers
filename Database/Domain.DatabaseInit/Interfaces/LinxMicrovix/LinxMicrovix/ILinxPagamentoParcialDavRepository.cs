namespace Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxMicrovix
{
    public interface ILinxPagamentoParcialDavRepository
    {
        public Task<bool> InsertParametersIfNotExists(string jobName, string parametersTableName, string databaseName);
        public bool CreateTableIfNotExists(string databaseName, string jobName, string untreatedDatabaseName);
        public Task<bool> CreateTableMerge(string databaseName, string tableName);
    }
}
