using IntegrationsCore.Domain.Entities;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.LinxCommerce
{
    public interface IB2CConsultaNFeSituacaoService<TEntity> where TEntity : class, new()
    {
        public List<TEntity?> DeserializeXMLToObject(LinxMicrovixJobParameter jobParameter, List<Dictionary<string?, string?>> records);
        public Task<bool> GetRecords(LinxMicrovixJobParameter jobParameter);
    }
}
