using Domain.IntegrationsCore.Entities.Parameters;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxMicrovix;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.LinxMicrovix
{
    public interface ILinxProdutosCodBarService
    {
        public List<LinxProdutosCodBar?> DeserializeXMLToObject(LinxMicrovixJobParameter jobParameter, List<Dictionary<string?, string?>> records);
        public Task<bool> GetRecords(LinxMicrovixJobParameter jobParameter);
        public Task<bool> GetRecord(LinxMicrovixJobParameter jobParameter, string? identificador, string? cnpj_emp);
    }
}
