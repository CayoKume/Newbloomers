using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaProdutosAssociadosRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosAssociados? record);
        public Task<bool> InsertParametersIfNotExists(LinxAPIParam jobParameter);
        public Task<bool> CreateTableMerge(LinxAPIParam jobParameter);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosAssociados> records);
        public Task<List<B2CConsultaProdutosAssociados>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosAssociados> registros);
    }
}
