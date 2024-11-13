using Domain.IntegrationsCore.Entities.Errors;

namespace Domain.IntegrationsCore.Interfaces
{
    public interface ILogStatusRepository
    {
        Task Update(LogStatus status);
    }
}

