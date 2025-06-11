using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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
