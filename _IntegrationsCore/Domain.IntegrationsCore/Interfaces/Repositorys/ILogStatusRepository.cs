using Domain.IntegrationsCore.Entities.Errors;

namespace Domain.IntegrationsCore.Interfaces.Repositorys
{
    public interface ILogStatusRepository
    {
        Task Update(LogStatus status);
    }
}

