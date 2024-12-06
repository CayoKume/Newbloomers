using Domain.DatabaseInit.Interfaces.Database;
using Domain.IntegrationsCore.Entities.Parameters;

namespace Infrastructure.DatabaseInit.Repositorys.Database
{
    public class DatabaseInitRepository : IDatabaseInitRepository
    {
        public Task<bool> CreateDatabasesIfNotExists(LinxMicrovixJobParameter linxMicrovixJobParameter)
        {
            throw new NotImplementedException();
        }
    }
}
