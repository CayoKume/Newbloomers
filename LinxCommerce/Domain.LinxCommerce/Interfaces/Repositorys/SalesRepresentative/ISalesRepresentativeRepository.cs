using Domain.LinxCommerce.Entities.Parameters;
using System.Data;

namespace Domain.LinxCommerce.Interfaces.Repositorys.SalesRepresentative
{
    public interface ISalesRepresentativeRepository
    {
        public bool BulkInsertIntoTableRaw(LinxCommerceJobParameter jobParameter, List<Domain.LinxCommerce.Entities.SalesRepresentative.SalesRepresentative> registros);
        public Task<List<Domain.LinxCommerce.Entities.SalesRepresentative.SalesRepresentative>> GetRegistersExists(List<string> ordersIds);
    }
}
