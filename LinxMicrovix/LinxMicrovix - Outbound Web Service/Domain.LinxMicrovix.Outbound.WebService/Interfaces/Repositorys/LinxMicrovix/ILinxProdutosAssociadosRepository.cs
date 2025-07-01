using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxProdutosAssociadosRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosAssociados? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosAssociados> records);
        public Task<IEnumerable<LinxProdutosAssociados>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosAssociados> registros);
    }
}
