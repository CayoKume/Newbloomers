using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxCommerce.Entities.Catolog.Sku;

namespace Domain.LinxCommerce.Interfaces.Repositorys.Catolog
{
    public interface ISKURepository
    {
        public Task<bool> InsertRecord(LinxCommerceJobParameter jobParameter, SKUs? record);
        public Task<bool> InsertParametersIfNotExists(LinxCommerceJobParameter jobParameter);
        public Task<bool> CreateTableMerge(LinxCommerceJobParameter jobParameter);
        public bool BulkInsertIntoTableRaw(LinxCommerceJobParameter jobParameter, List<SKUs> records);
    }
}
