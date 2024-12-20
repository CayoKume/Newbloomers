using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxProdutosAssociadosRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosAssociados? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosAssociados> records);
        public Task<List<LinxProdutosAssociados>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosAssociados> registros);
    }
}
