using Domain.IntegrationsCore.Entities.Errors;

namespace Domain.IntegrationsCore.Interfaces.Repositorys
{
    public interface ILogMsgsRepository
    {
        Task<int> BulkInsert(IList<LogMsg> pListLogMsg);
    }
}
