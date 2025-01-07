using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxClientesFornecCreditoAvulsoRepository : ILinxClientesFornecCreditoAvulsoRepository
    {
        public LinxClientesFornecCreditoAvulsoRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClientesFornecCreditoAvulso> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxClientesFornecCreditoAvulso>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClientesFornecCreditoAvulso> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClientesFornecCreditoAvulso? record)
        {
            throw new NotImplementedException();
        }
    }
}
