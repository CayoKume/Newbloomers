using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix_Outbound_Web_Service.Entites.LinxCommerce;

namespace Application.LinxMicrovix_Outbound_Web_Service.Interfaces.LinxCommerce
{
    public interface IB2CConsultaPalavrasChavePesquisaService
    {
        public List<B2CConsultaPalavrasChavePesquisa?> DeserializeXMLToObject(LinxMicrovixJobParameter jobParameter, List<Dictionary<string?, string?>> records);
        public Task<bool> GetRecords(LinxMicrovixJobParameter jobParameter);
    }
}
