using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxCategoriasFinanceirasRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCategoriasFinanceiras? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCategoriasFinanceiras> records);
        public Task<List<LinxCategoriasFinanceiras>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCategoriasFinanceiras> registros);
    }
}
