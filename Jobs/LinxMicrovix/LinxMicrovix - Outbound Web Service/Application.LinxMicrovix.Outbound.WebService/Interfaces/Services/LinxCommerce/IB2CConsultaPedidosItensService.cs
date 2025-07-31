using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Services.LinxCommerce
{
    public interface IB2CConsultaPedidosItensService
    {
        public List<B2CConsultaPedidosItens?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records);
        public Task<bool> GetRecords(LinxAPIParam jobParameter);
        public Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador);
    }
}
