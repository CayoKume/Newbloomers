using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxProdutosOpticosFormatoAroRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosOpticosFormatoAro? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosOpticosFormatoAro> records);
        public Task<List<LinxProdutosOpticosFormatoAro>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosOpticosFormatoAro> registros);
    }
}
