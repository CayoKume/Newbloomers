using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxMicrovix
{
    public interface ILinxProdutosPromocoesService
    {
        public List<LinxProdutosPromocoes?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records);
        public Task<bool> GetRecords(LinxAPIParam jobParameter);
        public Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador, string? cnpj_emp);
    }
}
