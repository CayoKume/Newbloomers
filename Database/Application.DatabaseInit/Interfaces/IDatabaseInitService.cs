using Domain.IntegrationsCore.Entities.Parameters;

namespace Application.DatabaseInit.Interfaces
{
    public interface IDatabaseInitService
    {
        public Task<bool> CreateDatabasesIfNotExists(LinxMicrovixJobParameter linxMicrovixJobParameter);
    }
}
