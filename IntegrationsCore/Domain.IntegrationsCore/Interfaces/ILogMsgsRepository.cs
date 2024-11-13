using Domain.IntegrationsCore.Entities.Errors;

namespace Domain.IntegrationsCore.Interfaces
{
    public interface ILogMsgsRepository
    {
        Task<int> BulkInsert(IList<LogMsg> pListLogMsg);
    }
}
