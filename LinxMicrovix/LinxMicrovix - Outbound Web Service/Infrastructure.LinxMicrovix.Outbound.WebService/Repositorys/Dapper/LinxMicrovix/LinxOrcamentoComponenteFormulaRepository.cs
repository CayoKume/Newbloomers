using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxOrcamentoComponenteFormulaRepository : ILinxOrcamentoComponenteFormulaRepository
    {
        public LinxOrcamentoComponenteFormulaRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxOrcamentoComponenteFormula> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxOrcamentoComponenteFormula>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxOrcamentoComponenteFormula> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxOrcamentoComponenteFormula? record)
        {
            throw new NotImplementedException();
        }
    }
}
