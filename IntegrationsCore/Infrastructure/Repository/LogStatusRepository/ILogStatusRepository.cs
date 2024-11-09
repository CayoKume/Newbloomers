using IntegrationsCore.Domain.Entities.Errors;

namespace IntegrationsCore.Infrastructure.Repository.LogStatusRepository
{
    public interface ILogStatusRepository
    {
        Task Update(LogStatus status);
    }
}

