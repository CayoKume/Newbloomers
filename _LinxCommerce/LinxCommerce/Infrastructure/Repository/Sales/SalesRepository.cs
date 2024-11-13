using IntegrationsCore.Domain.Entities;
using System.Data;

namespace LinxCommerce.Infrastructure.Repository.Sales
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
