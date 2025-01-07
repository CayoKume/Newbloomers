namespace Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxMicrovix
{
    public interface ILinxSerialVendaRepository
    {
        public Task<bool> InsertParametersIfNotExists(string jobName, string parametersTableName, string databaseName);
        public bool CreateDataTableIfNotExists(string databaseName, string jobName, string untreatedDatabaseName);
        public Task<bool> CreateTableMerge(string databaseName, string tableName);
    }
}
