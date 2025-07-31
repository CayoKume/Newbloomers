using Domain.Wms.Models;

namespace Domain.WebApi.Interfaces.Repositorys
{
    public interface IHomeRepository
    {
        public Task<IEnumerable<HomeOrder>?> GetPickupOrders(string doc_company);
    }
}
