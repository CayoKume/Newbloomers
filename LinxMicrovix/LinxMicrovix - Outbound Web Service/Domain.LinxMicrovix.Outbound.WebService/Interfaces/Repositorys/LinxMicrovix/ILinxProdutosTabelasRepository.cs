using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxProdutosTabelasRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosTabelas? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosTabelas> records);
        public Task<List<string?>> GetRegistersExists();
    }
}
