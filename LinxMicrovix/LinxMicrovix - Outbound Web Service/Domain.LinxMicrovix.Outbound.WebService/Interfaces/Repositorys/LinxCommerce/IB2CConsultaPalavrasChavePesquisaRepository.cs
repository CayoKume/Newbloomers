using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaPalavrasChavePesquisaRepository
    {
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaPalavrasChavePesquisa> records);
        public Task<List<B2CConsultaPalavrasChavePesquisa>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaPalavrasChavePesquisa> registros);
    }
}
