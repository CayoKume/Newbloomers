using Domain.IntegrationsCore.Entities.Errors;

namespace Domain.IntegrationsCore.Interfaces
{
    public interface ILogRepository
    {
        public Task<bool> LogInsert(Log log);
    }
}
