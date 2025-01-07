using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxSpedTipoBaseCreditoRepository : ILinxSpedTipoBaseCreditoRepository
    {
        public LinxSpedTipoBaseCreditoRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxSpedTipoBaseCredito> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxSpedTipoBaseCredito>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxSpedTipoBaseCredito> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxSpedTipoBaseCredito? record)
        {
            throw new NotImplementedException();
        }
    }
}
