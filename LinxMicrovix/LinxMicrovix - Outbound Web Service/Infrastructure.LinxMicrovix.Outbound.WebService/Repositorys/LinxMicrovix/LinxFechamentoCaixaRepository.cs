using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxFechamentoCaixaRepository : ILinxFechamentoCaixaRepository
    {
        public LinxFechamentoCaixaRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxFechamentoCaixa> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxFechamentoCaixa>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxFechamentoCaixa> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxFechamentoCaixa? record)
        {
            throw new NotImplementedException();
        }
    }
}
