using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Application.DatabaseInit.Interfaces
{
    public interface IDatabaseInitService
    {
        public Task<bool> CreateDatabasesIfNotExists(List<string> databases);
    }
}
