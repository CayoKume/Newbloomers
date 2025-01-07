using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxECFFormasPagamentoRepository : ILinxECFFormasPagamentoRepository
    {
        public LinxECFFormasPagamentoRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxECFFormasPagamento> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxECFFormasPagamento>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxECFFormasPagamento> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxECFFormasPagamento? record)
        {
            throw new NotImplementedException();
        }
    }
}
