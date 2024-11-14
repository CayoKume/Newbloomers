using Domain.IntegrationsCore.Entities.Errors;

namespace Domain.IntegrationsCore.Interfaces
{
    public interface ILogDetailsRepository
    {
        Task<int> BulkInsert(IList<ILogMsgsDetail> pListLogDetails);
    }
}
