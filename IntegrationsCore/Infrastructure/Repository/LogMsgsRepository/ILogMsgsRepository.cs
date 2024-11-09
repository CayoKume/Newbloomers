using IntegrationsCore.Domain.Entities.Errors;

namespace IntegrationsCore.Infrastructure.Repository.LogMsgsRepository
{
    public interface ILogMsgsRepository
    {
        Task<int> BulkInsert(IList<LogMsg> pListLogMsg);
    }
}
