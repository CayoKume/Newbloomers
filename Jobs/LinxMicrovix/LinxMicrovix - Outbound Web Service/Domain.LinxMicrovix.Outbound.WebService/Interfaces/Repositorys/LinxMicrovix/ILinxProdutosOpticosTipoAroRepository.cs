using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxProdutosOpticosTipoAroRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosOpticosTipoAro? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosOpticosTipoAro> records);
        public Task<IEnumerable<LinxProdutosOpticosTipoAro>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosOpticosTipoAro> registros);
    }
}
