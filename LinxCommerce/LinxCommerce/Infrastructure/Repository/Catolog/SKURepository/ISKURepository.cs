using IntegrationsCore.Domain.Entities.Parameters;
using LinxCommerce.Domain.Entities.Catolog.Sku;

namespace LinxCommerce.Infrastructure.Repository.Catolog.SKURepository
{
    public interface ISKURepository
    {
        public Task<bool> InsertRecord(LinxCommerceJobParameter jobParameter, SKUs? record);
        public Task<bool> InsertParametersIfNotExists(LinxCommerceJobParameter jobParameter);
        public Task<bool> CreateTableMerge(LinxCommerceJobParameter jobParameter);
        public bool BulkInsertIntoTableRaw(LinxCommerceJobParameter jobParameter, List<SKUs> records);
    }
}
