using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxProdutosOpticosTipoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosOpticosTipo? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosOpticosTipo> records);
        public Task<List<LinxProdutosOpticosTipo>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosOpticosTipo> registros);
    }
}
