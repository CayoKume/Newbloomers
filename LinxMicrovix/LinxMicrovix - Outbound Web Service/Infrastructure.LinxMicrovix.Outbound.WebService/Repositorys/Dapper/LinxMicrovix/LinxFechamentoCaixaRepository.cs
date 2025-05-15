using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
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
