using Domain.LinxCommerce.Entities.Parameters;
using System.Data;

namespace Domain.LinxCommerce.Interfaces.Repositorys.Sales
{
    public interface ISalesRepository<TEntity> where TEntity : class, new()
    {
        public Task<bool> CreateDataTableIfNotExists(LinxCommerceJobParameter jobParameter);
        public DataTable CreateSystemDataTable(LinxCommerceJobParameter jobParameter, TEntity entity);
    }
}
