using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMovimentoCamposAdicionaisRepository : ILinxMovimentoCamposAdicionaisRepository
    {
        public LinxMovimentoCamposAdicionaisRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoCamposAdicionais> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMovimentoCamposAdicionais>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoCamposAdicionais> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoCamposAdicionais? record)
        {
            throw new NotImplementedException();
        }
    }
}
