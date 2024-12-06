using Domain.IntegrationsCore.Entities.Parameters;

namespace Domain.DatabaseInit.Interfaces.Database
{
    public interface IDatabaseInitRepository
    {
        public Task<bool> CreateDatabasesIfNotExists(LinxMicrovixJobParameter linxMicrovixJobParameter);
    }
}
