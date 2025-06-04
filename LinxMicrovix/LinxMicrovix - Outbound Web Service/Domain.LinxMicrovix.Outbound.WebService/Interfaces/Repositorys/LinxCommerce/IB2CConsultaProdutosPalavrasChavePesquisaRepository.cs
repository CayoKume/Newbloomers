using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaProdutosPalavrasChavePesquisaRepository
    {
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosPalavrasChavePesquisa> records);
        public Task<List<B2CConsultaProdutosPalavrasChavePesquisa>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosPalavrasChavePesquisa> registros);
    }
}
