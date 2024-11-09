using IntegrationsCore.Domain.Entities.Errors;

namespace IntegrationsCore.Infrastructure.Repositorys.LogDetailsRepository
{
    public interface ILogDetailsRepository
    {
        Task<int> BulkInsert(IList<LogMsgsDetail> pListLogDetails);
    }
}
