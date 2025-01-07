namespace Application.DatabaseInit.Interfaces
{
    public interface IDatabaseInitService
    {
        public Task<bool> CreateDatabasesIfNotExists(List<string> databases);
    }
}
