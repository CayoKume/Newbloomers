using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxProdutosSerialRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosSerial? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosSerial> records);
        public Task<List<LinxProdutosSerial>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosSerial> registros);
    }
}
