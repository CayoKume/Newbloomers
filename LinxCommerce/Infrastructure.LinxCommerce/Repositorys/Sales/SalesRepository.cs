using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxCommerce.Interfaces.Repositorys.Sales;
using System.Data;

namespace Infrastructure.LinxCommerce.Repository.Sales
{
    public class SalesRepository<TEntity> : ISalesRepository<TEntity> where TEntity : class, new()
    {
        public Task<bool> CreateDataTableIfNotExists(LinxMicrovixJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public DataTable CreateSystemDataTable(LinxMicrovixJobParameter jobParameter, TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
