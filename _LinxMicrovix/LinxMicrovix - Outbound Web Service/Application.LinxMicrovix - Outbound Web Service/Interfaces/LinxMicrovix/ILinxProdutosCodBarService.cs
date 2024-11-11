using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix_Outbound_Web_Service.Entites.LinxMicrovix;

namespace Application.LinxMicrovix_Outbound_Web_Service.Interfaces.LinxMicrovix
{
    public interface ILinxProdutosCodBarService
    {
        public List<LinxProdutosCodBar?> DeserializeXMLToObject(LinxMicrovixJobParameter jobParameter, List<Dictionary<string?, string?>> records);
        public Task<bool> GetRecords(LinxMicrovixJobParameter jobParameter);
        public Task<bool> GetRecord(LinxMicrovixJobParameter jobParameter, string? identificador, string? cnpj_emp);
    }
}
