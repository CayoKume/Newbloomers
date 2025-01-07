using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxProdutosCodBarRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosCodBar? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, List<LinxProdutosCodBar> records);
        public Task<List<LinxProdutosCodBar>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosCodBar> registros);

    }
}
