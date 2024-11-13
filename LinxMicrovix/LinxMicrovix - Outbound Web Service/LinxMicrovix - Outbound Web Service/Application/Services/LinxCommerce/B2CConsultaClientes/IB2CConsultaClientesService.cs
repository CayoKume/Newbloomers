using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.LinxCommerce
{
    public interface IB2CConsultaClientesService
    {
        public List<B2CConsultaClientes?> DeserializeXMLToObject(LinxMicrovixJobParameter jobParameter, List<Dictionary<string?, string?>> records);
        public Task<bool> GetRecords(LinxMicrovixJobParameter jobParameter);
        public Task<bool> GetRecord(LinxMicrovixJobParameter jobParameter, string? identificador, string? cnpj_emp);
    }
}
