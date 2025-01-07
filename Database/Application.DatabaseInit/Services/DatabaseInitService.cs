using Application.DatabaseInit.Interfaces;
using Domain.DatabaseInit.Interfaces.Database;

namespace Application.DatabaseInit.Services
{
    public class DatabaseInitService : IDatabaseInitService
    {
        private readonly IDatabaseInitRepository _databaseInitRepository;

        public DatabaseInitService(IDatabaseInitRepository databaseInitRepository) =>
            _databaseInitRepository = databaseInitRepository;

        public async Task<bool> CreateDatabasesIfNotExists(List<string> databases)
        {
            try
            {
                return await _databaseInitRepository.CreateDatabasesIfNotExists(databases);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
