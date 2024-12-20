using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxSpedTipoBaseCreditoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxSpedTipoBaseCredito? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxSpedTipoBaseCredito> records);
        public Task<List<LinxSpedTipoBaseCredito>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxSpedTipoBaseCredito> registros);
    }
}
