using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxAntecipacoesFinanceirasPlanosRepository : ILinxAntecipacoesFinanceirasPlanosRepository
    {
        public LinxAntecipacoesFinanceirasPlanosRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxAntecipacoesFinanceirasPlanos> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxAntecipacoesFinanceirasPlanos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxAntecipacoesFinanceirasPlanos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxAntecipacoesFinanceirasPlanos? record)
        {
            throw new NotImplementedException();
        }
    }
}
