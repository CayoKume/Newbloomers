using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMotivoDescontoRepository : ILinxMotivoDescontoRepository
    {
        public LinxMotivoDescontoRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMotivoDesconto> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMotivoDesconto>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMotivoDesconto> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMotivoDesconto? record)
        {
            throw new NotImplementedException();
        }
    }
}
