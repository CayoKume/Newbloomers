

namespace Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxCommerce
{
    public interface IB2CConsultaUnidadeRepository
    {
        public Task<bool> InsertParametersIfNotExists(string jobName, string parametersTableName, string databaseName);
        public bool CreateDataTableIfNotExists(string databaseName, string jobName, string untreatedDatabaseName);
        public Task<bool> CreateTableMerge(string databaseName, string tableName);
    }
}
