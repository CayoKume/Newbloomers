using Application.DatabaseInit.Interfaces;
using Domain.IntegrationsCore.Entities.Parameters;

namespace Application.DatabaseInit.Services
{
    public class DatabaseInitService : IDatabaseInitService
    {
        public async Task<bool> CreateDatabasesIfNotExists(LinxMicrovixJobParameter linxMicrovixJobParameter)
        {
            throw new NotImplementedException();
        }
    }
}
