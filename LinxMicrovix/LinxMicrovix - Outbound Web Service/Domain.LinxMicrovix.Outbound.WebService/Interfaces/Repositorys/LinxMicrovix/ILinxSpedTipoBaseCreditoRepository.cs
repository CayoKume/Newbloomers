using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxSpedTipoBaseCreditoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxSpedTipoBaseCredito? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxSpedTipoBaseCredito> records);
        public Task<IEnumerable<LinxSpedTipoBaseCredito>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxSpedTipoBaseCredito> registros);
    }
}
