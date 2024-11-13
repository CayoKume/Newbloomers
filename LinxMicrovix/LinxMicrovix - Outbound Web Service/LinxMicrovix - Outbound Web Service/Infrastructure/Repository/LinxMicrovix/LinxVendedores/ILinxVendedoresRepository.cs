using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxMicrovix;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxMicrovix
{
    public interface ILinxVendedoresRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, LinxVendedores? record);
        public Task<bool> InsertParametersIfNotExists(LinxMicrovixJobParameter jobParameter);
        public Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<LinxVendedores> records);
    }
}
