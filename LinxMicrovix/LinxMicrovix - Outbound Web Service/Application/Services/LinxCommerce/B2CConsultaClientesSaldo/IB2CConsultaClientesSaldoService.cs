using IntegrationsCore.Domain.Entities;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.LinxCommerce
{
    public interface IB2CConsultaClientesSaldoService<TEntity> where TEntity : class, new()
    {
        public List<TEntity?> DeserializeXMLToObject(JobParameter jobParameter, List<Dictionary<string, string>> records);
        public Task<bool> GetRecords(JobParameter jobParameter);
        public Task<bool> GetRecord(JobParameter jobParameter, string? identificador, string? cnpj_emp);
    }
}
