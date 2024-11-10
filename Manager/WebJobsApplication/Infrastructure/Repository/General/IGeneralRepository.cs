namespace WebJobsApplication.Infrastructure.Repository.General
{
    public interface IGeneralRepository<TEntity> where TEntity : class, new()
    {
        public Task<bool> CreateDatabaseIfNotExists(string? projectName, string? databaseName);
        public Task<bool> CreateParametersDataTableIfNotExists(string? projectName, string? databaseName, string? tableName);
    }
}
