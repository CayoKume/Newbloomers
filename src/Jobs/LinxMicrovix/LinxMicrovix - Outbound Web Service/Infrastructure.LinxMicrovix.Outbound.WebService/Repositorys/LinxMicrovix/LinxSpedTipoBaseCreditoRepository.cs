using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxSpedTipoBaseCredito>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxSpedTipoBaseCredito> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxSpedTipoBaseCredito? record)
        {
            throw new NotImplementedException();
        }
    }
}
