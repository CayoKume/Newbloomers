namespace WebJobsApplication.Infrastructure.Connections.LinxMicrovix
{
    public interface ILinxMicrovixRepository<TEntity> where TEntity : class, new()
    {
        public Task<bool> CreateDatabaseIfNotExists(string? projectName, string? databaseName);
        public Task<bool> CreateParametersDataTableIfNotExists(string? projectName, string? databaseName, string? tableName);
    }
}
