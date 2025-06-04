

namespace Domain.DatabaseInit.Interfaces.Database
{
    public interface IDatabaseInitRepository
    {
        public Task<bool> CreateDatabasesIfNotExists(List<string> databases);
    }
}
