using Domain.IntegrationsCore.Entities.Auditing;

namespace Domain.IntegrationsCore.Interfaces
{
    public interface ILogRepository
    {
        public Task<bool> LogInsert(Log log);
    }
}
