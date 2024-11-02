using IntegrationsCore.Domain.Entities;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.LinxMicrovix
{
    public interface ILinxVendedoresService<TEntity> where TEntity : class, new()
    {
        public List<TEntity?> DeserializeXMLToObject(LinxMicrovixJobParameter jobParameter, List<Dictionary<string?, string?>> records);
        public Task<bool> GetRecords(LinxMicrovixJobParameter jobParameter);
        public Task<bool> GetRecord(LinxMicrovixJobParameter jobParameter, string? identificador, string? cnpj_emp);
    }
}
