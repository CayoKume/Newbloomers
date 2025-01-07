using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.DatabaseInit.Repositorys.LinxMicrovix.LinxMicrovix
{
    public class LinxMovimentoReshopItens : ILinxMovimentoReshopItens
    {
        public bool CreateDataTableIfNotExists(string databaseName, string jobName, string untreatedDatabaseName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateTableMerge(string databaseName, string tableName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertParametersIfNotExists(string jobName, string parametersTableName, string databaseName)
        {
            throw new NotImplementedException();
        }
    }
}
