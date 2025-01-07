using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMovimentoRepository : ILinxMovimentoRepository
    {
        public LinxMovimentoRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimento> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMovimento>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimento> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimento? record)
        {
            throw new NotImplementedException();
        }
    }
}
