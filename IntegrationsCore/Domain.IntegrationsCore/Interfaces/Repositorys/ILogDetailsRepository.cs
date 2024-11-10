using Domain.IntegrationsCore.Entities.Errors;

namespace Domain.IntegrationsCore.Interfaces.Repositorys
{
    public interface ILogDetailsRepository
    {
        Task<int> BulkInsert(IList<LogMsgsDetail> pListLogDetails);
    }
}
