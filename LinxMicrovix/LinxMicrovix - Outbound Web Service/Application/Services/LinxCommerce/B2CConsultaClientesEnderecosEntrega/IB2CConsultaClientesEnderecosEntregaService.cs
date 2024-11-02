using IntegrationsCore.Domain.Entities;
using static Dapper.SqlMapper;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.LinxCommerce
{
    public interface IB2CConsultaClientesEnderecosEntregaService<TEntity> where TEntity : class, new()
    {
        public List<TEntity?> DeserializeXMLToObject(LinxMicrovixJobParameter jobParameter, List<Dictionary<string?, string?>> records);
        public Task<bool> GetRecords(LinxMicrovixJobParameter jobParameter);
        public Task<bool> GetRecord(LinxMicrovixJobParameter jobParameter, string? identificador, string? cnpj_emp);
    }
}
