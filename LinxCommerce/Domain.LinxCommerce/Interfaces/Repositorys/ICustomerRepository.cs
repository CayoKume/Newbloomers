using Domain.LinxCommerce.Entities.Parameters;

namespace Domain.LinxCommerce.Interfaces.Repositorys
{
    public interface ICustomerRepository
    {
        public bool BulkInsertIntoTableRaw(LinxCommerceJobParameter jobParameter, List<Domain.LinxCommerce.Entities.Customer.Person> registros);
        public Task<List<Domain.LinxCommerce.Entities.Customer.Person>> GetRegistersExists(IEnumerable<int> customerIds);
    }
}
