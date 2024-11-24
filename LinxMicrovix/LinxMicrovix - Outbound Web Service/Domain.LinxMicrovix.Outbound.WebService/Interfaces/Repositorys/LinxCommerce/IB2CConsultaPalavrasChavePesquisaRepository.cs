using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaPalavrasChavePesquisaRepository
    {
        public Task<bool> InsertParametersIfNotExists(LinxMicrovixJobParameter jobParameter);
        public Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<B2CConsultaPalavrasChavePesquisa> records);
        public Task<List<B2CConsultaPalavrasChavePesquisa>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<B2CConsultaPalavrasChavePesquisa> registros);
    }
}
