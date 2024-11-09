namespace WebJobsApplication.Infrastructure.Connections.LinxCommerce
{
    public interface ILinxCommerceRepository<TEntity> where TEntity : class, new()
    {
        public Task<bool> CreateDatabaseIfNotExists(string? projectName, string? databaseName);
        public Task<bool> CreateParametersDataTableIfNotExists(string? projectName, string? databaseName, string? tableName);
    }
}