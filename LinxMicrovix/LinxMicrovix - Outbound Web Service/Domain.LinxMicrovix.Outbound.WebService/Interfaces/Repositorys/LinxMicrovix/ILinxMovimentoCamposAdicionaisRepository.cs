using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoCamposAdicionaisRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoCamposAdicionais? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoCamposAdicionais> records);
        public Task<List<LinxMovimentoCamposAdicionais>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoCamposAdicionais> registros);
    }
}
