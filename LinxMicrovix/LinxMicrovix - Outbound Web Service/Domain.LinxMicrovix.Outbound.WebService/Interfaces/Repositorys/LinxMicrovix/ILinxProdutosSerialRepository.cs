using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxProdutosSerialRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosSerial? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosSerial> records);
        public Task<IEnumerable<LinxProdutosSerial>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosSerial> registros);
    }
}
