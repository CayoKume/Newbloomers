using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxProdutosCamposAdicionaisRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosCamposAdicionais? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosCamposAdicionais> records);
        public Task<IEnumerable<string>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosCamposAdicionais> registros);
    }
}
