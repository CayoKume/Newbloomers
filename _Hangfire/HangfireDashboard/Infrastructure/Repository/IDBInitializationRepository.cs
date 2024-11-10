namespace HangfireDashboard.Infrastructure.Repository
{
    public interface IDBInitializationRepository<TEntity> where TEntity : class
    {
        public Task<bool> CreateDatabaseIfNotExists(string? projectName, string? databaseName);
        public Task<bool> CreateParametersDataTableIfNotExists(string? projectName, string? databaseName, string? tableName);
    }
}
