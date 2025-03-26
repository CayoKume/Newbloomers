using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxProdutosCamposAdicionaisRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosCamposAdicionais? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosCamposAdicionais> records);
        public Task<List<string>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosCamposAdicionais> registros);
    }
}
