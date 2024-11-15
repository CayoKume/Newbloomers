using Domain.IntegrationsCore.Entities.Parameters;
using System.Data;

namespace Domain.LinxCommerce.Interfaces.Repositorys.Sales
{
    public interface ISalesRepository<TEntity> where TEntity : class, new()
    {
        public Task<bool> CreateDataTableIfNotExists(LinxMicrovixJobParameter jobParameter);
        public DataTable CreateSystemDataTable(LinxMicrovixJobParameter jobParameter, TEntity entity);
    }
}
