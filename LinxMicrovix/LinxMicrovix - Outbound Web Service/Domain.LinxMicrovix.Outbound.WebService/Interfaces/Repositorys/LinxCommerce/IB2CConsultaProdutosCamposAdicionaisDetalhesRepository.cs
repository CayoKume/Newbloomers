using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaProdutosCamposAdicionaisDetalhesRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaProdutosCamposAdicionaisDetalhes? record);
        public Task<bool> InsertParametersIfNotExists(LinxMicrovixJobParameter jobParameter);
        public Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<B2CConsultaProdutosCamposAdicionaisDetalhes> records);
        public Task<List<B2CConsultaProdutosCamposAdicionaisDetalhes>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<B2CConsultaProdutosCamposAdicionaisDetalhes> registros);
    }
}
